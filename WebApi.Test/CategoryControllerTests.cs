using Core.Entities;
using Core.Interfaces.Services;
using Core.ViewModels.ContentCategoryViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.AutoMapper.Interfaces;
using WebApi.Controllers;
using Xunit;

namespace WebApi.Test
{
    public class CategoryControllerTests
    {
        private readonly Mock<ICategoryService> _categoryServiceMock;
        private readonly Mock<IEnumerableViewModelMapper<IEnumerable<ContentCategory>, IEnumerable<ContentCategoryReadListViewModel>>> _readMapperMock;
        private readonly CategoryController _categoryController;
        public CategoryControllerTests()
        {
            _categoryServiceMock = new Mock<ICategoryService>();
            _readMapperMock = new Mock<IEnumerableViewModelMapper<IEnumerable<ContentCategory>, IEnumerable<ContentCategoryReadListViewModel>>>();
            _categoryController = new CategoryController(_categoryServiceMock.Object, _readMapperMock.Object);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnCats()
        {
            // Arrange
            var listOfCats = new List<ContentCategory>();
            var vms = new List<ContentCategoryReadListViewModel>();

            _categoryServiceMock
                .Setup(x => x
                    .GetCategoryAsync())
                .ReturnsAsync(listOfCats);

            _readMapperMock
                .Setup(x => x.Map(listOfCats)).Returns(vms);

            // Act
            var result = await _categoryController.GetAsync();

            // Assert
            Assert.Equal(vms, result);
        }
    }
}
