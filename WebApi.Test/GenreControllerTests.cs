using Core.Entities;
using Core.Interfaces.Services;
using Core.Paginator;
using Core.ViewModels.GenreViewModels;
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
    public class GenreControllerTests
    {
        private readonly Mock<IGenreService> _genreServiceMock;
        private readonly Mock<IViewModelMapper<GenreCreateViewModel, Genre>> _genreCreateMapperMock;
        private readonly Mock<IViewModelMapper<GenreUpdateViewModel, Genre>> _genreUpdateMapperMock;
        private readonly Mock<IViewModelMapper<PagedList<Genre>, PagedReadViewModel<GenreUpdateViewModel>>> _pagedListMapperMock;
        private readonly GenreController _genreController;

        public GenreControllerTests()
        {
            _genreServiceMock = new Mock<IGenreService>();
            _genreCreateMapperMock = new Mock<IViewModelMapper<GenreCreateViewModel, Genre>>();
            _genreUpdateMapperMock = new Mock<IViewModelMapper<GenreUpdateViewModel, Genre>>();
            _pagedListMapperMock = new Mock<IViewModelMapper<PagedList<Genre>, PagedReadViewModel<GenreUpdateViewModel>>>();
            _genreController = new GenreController(
                _genreServiceMock.Object,
                _genreCreateMapperMock.Object,
                _genreUpdateMapperMock.Object,
                _pagedListMapperMock.Object);
        }

        [Fact]
        public async Task GetAsyncTest()
        {
            var genreParameters = new GenreParameters();
            var genres = new PagedList<Genre>(new List<Genre>(), 1, 1, 1);
            var viewModels = new PagedReadViewModel<GenreUpdateViewModel>();

            _genreServiceMock
                .Setup(x => x
                    .GetGenreAsync(It.IsAny<GenreParameters>())).ReturnsAsync(genres);

            _pagedListMapperMock.Setup(m => m.Map(It.IsAny<PagedList<Genre>>())).Returns(viewModels);

            // Act
            var result = await _genreController.GetAsync(genreParameters);

            // Assert
            Assert.Equal(viewModels, result);
        }

        [Fact]
        public async Task CreateGenreAsync_ShouldCreate()
        {
            var genreCreateViewModel = new GenreCreateViewModel();
            var genre = new Genre();

            _genreCreateMapperMock.Setup(m => m.Map(It.IsAny<GenreCreateViewModel>())).Returns(genre);

            _genreServiceMock
                .Setup(s => s
                    .CreateGenreAsync(It.IsAny<Genre>())).Verifiable();

            // Act
            await _genreController.CreateGenreAsync(genreCreateViewModel);
            
            // Assert
            _genreServiceMock.Verify(x => x.CreateGenreAsync(genre), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdate()
        {
            // Arrange
            var genreUpdateViewModel = new GenreUpdateViewModel();
            var genre = new Genre();
            
            _genreUpdateMapperMock.Setup(m => m.Map(It.IsAny<GenreUpdateViewModel>())).Returns(genre);
            
            _genreServiceMock
                .Setup(s => s
                    .UpdateGenreAsync(It.IsAny<Genre>()))
                .Verifiable();
            
            // Act
            await _genreController.UpdateAsync(genreUpdateViewModel);
            
            // Assert
            _genreServiceMock.Verify(x => x.UpdateGenreAsync(genre), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldDelete()
        {
            // Arrange
            var genreId = 1;
            
            _genreServiceMock
                .Setup(s => s
                    .DeleteGenreAsync(It.IsAny<int>()))
                .Verifiable();
            
            // Act
            await _genreController.DeleteAsync(genreId);
            
            // Assert
            _genreServiceMock.Verify(x => x.DeleteGenreAsync(genreId), Times.Once);
        }
    }
}
