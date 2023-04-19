using Core.Entities;
using Core.Interfaces.Services;
using Core.Paginator;
using Core.ViewModels.ContentViewModels;
using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.AutoMapper.Interfaces;
using Moq;
using WebApi.Controllers;
using Xunit;
using Core.Paginator.Parameters;

namespace WebApi.Test
{
    public class ContentControllerTests
    {
        private readonly Mock<IContenService> _contenServiceMock;
        private readonly Mock<IViewModelMapper<ContentCreateViewModel, Content>> _createMapperMock;
        private readonly Mock<IViewModelMapper<ContentUpdateViewModel, Content>> _updateMapperMock;
        private readonly Mock<IViewModelMapper<Content, ContentReadViewModel>> _readMapperMock;
        private readonly Mock<IEnumerableViewModelMapper<IEnumerable<Content>, IEnumerable<ContentListReadViewModel>>> _readListMapperMock;
        private readonly Mock<IViewModelMapper<PagedList<Content>, PagedReadViewModel<ContentListReadViewModel>>> _pagedListMapperMock;
        private readonly ContentController _contentController;

        public ContentControllerTests()
        {
            _contenServiceMock = new Mock<IContenService>();
            _createMapperMock = new Mock<IViewModelMapper<ContentCreateViewModel, Content>>();
            _updateMapperMock = new Mock<IViewModelMapper<ContentUpdateViewModel, Content>>();
            _readMapperMock = new Mock<IViewModelMapper<Content, ContentReadViewModel>>();
            _readListMapperMock = new Mock<IEnumerableViewModelMapper<IEnumerable<Content>, IEnumerable<ContentListReadViewModel>>>();
            _pagedListMapperMock = new Mock<IViewModelMapper<PagedList<Content>, PagedReadViewModel<ContentListReadViewModel>>>();
            _contentController = new ContentController(
                _contenServiceMock.Object,
                _createMapperMock.Object,
                _updateMapperMock.Object,
                _readMapperMock.Object,
                _pagedListMapperMock.Object,
                _readListMapperMock.Object);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnContents()
        {
            // Arrange
            var contentParameters = new ContentParameters();
            var contents = new PagedList<Content>(new List<Content>(), 1, 1, 1);
            var contentListReadViewModels = new List<ContentListReadViewModel>();
            var pagedReadViewModel = new PagedReadViewModel<ContentListReadViewModel>();

            _contenServiceMock
                .Setup(x => x
                    .GetContentsAsync(contentParameters))
                .ReturnsAsync(contents);
            
            _pagedListMapperMock
                .Setup(x => x.Map(contents)).Returns(pagedReadViewModel);
            
            // Act
            var result = await _contentController.GetAsync(contentParameters);
            
            // Assert
            Assert.Equal(pagedReadViewModel, result);
        }

        [Fact]
        public async Task GetAsyncById_ShouldReturnContent()
        {
            // Arrange
            var id = 1;
            var content = new Content();
            var contentReadViewModel = new ContentReadViewModel();

            _contenServiceMock
                .Setup(x => x
                    .GetContentByIdAsync(id))
                .ReturnsAsync(content);
            
            _readMapperMock
                .Setup(x => x.Map(content)).Returns(contentReadViewModel);
            
            // Act
            var result = await _contentController.GetAsync(id);
            
            // Assert
            Assert.Equal(contentReadViewModel, result);
        }

        [Fact]
        public async Task CreateContent_ShouldCreate()
        {
            // Arrange
            var contentCreateViewModel = new ContentCreateViewModel();
            var content = new Content();
            var aIds = new List<int>();
            var gIds = new List<int>();
            var contentReadViewModel = new ContentReadViewModel();

            _createMapperMock
                .Setup(x => x.Map(It.IsAny<ContentCreateViewModel>())).Returns(content);

            _contenServiceMock
                .Setup(x => x
                    .CreateContentAsync(It.IsAny<Content>(), It.IsAny<IEnumerable<int>>(), It.IsAny<IEnumerable<int>>()))
                .Verifiable();
                        
            // Act
            await _contentController.CreateContent(contentCreateViewModel);
            
            // Assert
            _contenServiceMock.Verify(s=>s.CreateContentAsync(content, aIds, gIds), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldDelete()
        {
            // Arrange
            var id = 1;
            var content = new Content();

            _contenServiceMock
                .Setup(x => x
                    .GetContentByIdAsync(It.IsAny<int>()))
                .Verifiable();
            
            // Act
            await _contentController.DeleteAsync(id);
            
            // Assert
            _contenServiceMock.Verify(s=>s.DeleteContentAsync(id), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdate()
        {
            // Arrange
            var id = 1;
            var contentUpdateViewModel = new ContentUpdateViewModel();
            var content = new Content();
            var aIds = new List<int>();
            var gIds = new List<int>();
            var contentReadViewModel = new ContentReadViewModel();

            _updateMapperMock
                .Setup(x => x.Map(It.IsAny<ContentUpdateViewModel>())).Returns(content);
            
            _contenServiceMock
                .Setup(x => x
                    .UpdateContentAsync(It.IsAny<Content>(), It.IsAny<IEnumerable<int>>(), It.IsAny<IEnumerable<int>>()))
                .Verifiable();
                        
            // Act
            await _contentController.UpdateAsync(contentUpdateViewModel);
            
            // Assert
            _contenServiceMock.Verify(s=>s.UpdateContentAsync(content, aIds, gIds), Times.Once);
        }

        [Fact]
        public async Task GetTop20Async_ShouldGettop20All()
        {
            // Arrange
            var contents = new List<Content>();
            var contentListReadViewModels = new List<ContentListReadViewModel>();

            _contenServiceMock
                .Setup(x => x
                    .GetTop20ContentAsync())
                .ReturnsAsync(contents);

            _readListMapperMock
                .Setup(x => x.Map(It.IsAny<IEnumerable<Content>>())).Returns(contentListReadViewModels);

            // Act
            var result = await _contentController.GetTop20Async();

            // Assert
            Assert.Equal(contentListReadViewModels, result);
        }

        [Fact]
        public async Task GetTop20AsyncByCat_ShouldGet20()
        {
            // Arrange
            var catId = 1;
            var contents = new List<Content>();
            var contentListReadViewModels = new List<ContentListReadViewModel>();

            _contenServiceMock
                .Setup(x => x
                    .GetTop20ContentByCategoryAsync(It.IsAny<int>()))
                .ReturnsAsync(contents);

            _readListMapperMock.Setup(x => x.Map(It.IsAny<IEnumerable<Content>>())).Returns(contentListReadViewModels);

            // Act
            var result = await _contentController.GetTop20Async(catId);

            // Assert
            Assert.Equal(contentListReadViewModels, result);
        }
    }
}
