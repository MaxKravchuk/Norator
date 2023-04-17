using Application.Services;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Paginator.Parameters;
using Core.Paginator;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Test
{
    public class CategoryServiceTests
    {
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
        private readonly Mock<ILoggerManager> _loggerManagerMock;
        private readonly CategoryService _categoryService;

        public CategoryServiceTests()
        {
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _loggerManagerMock = new Mock<ILoggerManager>();
            _categoryService = new CategoryService(
                _categoryRepositoryMock.Object,
                _loggerManagerMock.Object);
        }

        [Fact]
        public async Task CreateCategoryAsync_CreatesCategoryAndLogsInfo()
        {
            // Arrange
            var categoryToAdd = new ContentCategory { Id = 1, Name = "Action" };

            // Act
            await _categoryService.CreateCategoryAsync(categoryToAdd);

            // Assert
            _categoryRepositoryMock.Verify(repo => repo.InsertAsync(categoryToAdd), Times.Once);
            _categoryRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);
            _loggerManagerMock.Verify(logger => logger.LogInfo("Created category successful"), Times.Once);
        }

        [Fact]
        public async Task CreateCategoryAsync_LogsError_WhenSaveChangesFails()
        {
            // Arrange
            var categoryToAdd = new ContentCategory { Id = 1, Name = "Action" };

            _categoryRepositoryMock.Setup(repo => repo.SaveChangesAsync()).ThrowsAsync(new Exception());

            // Act
            await _categoryService.CreateCategoryAsync(categoryToAdd);

            // Assert
            _categoryRepositoryMock.Verify(repo => repo.InsertAsync(categoryToAdd), Times.Once);
            _categoryRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);
            _loggerManagerMock.Verify(logger => logger.LogError($"Created category error - {It.IsAny<string>()}"), Times.Once);
        }

        [Fact]
        public async Task DeleteCategoryAsync_DeletesCategoryAndLogsInfo()
        {
            // Arrange
            var categoryId = 1;

            _categoryRepositoryMock
                .Setup(repo => repo
                    .GetByIdAsync(It.IsAny<int>(),It.IsAny<string>()))
                .ReturnsAsync(new ContentCategory { Id = categoryId, Name = "Action" });

            // Act
            await _categoryService.DeleteCategoryAsync(categoryId);

            // Assert
            _categoryRepositoryMock.Verify(repo => repo.Delete(It.IsAny<ContentCategory>()), Times.Once);
            _categoryRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);
            _loggerManagerMock.Verify(logger => logger.LogInfo($"Deleted category {categoryId} successful"), Times.Once);
        }

        [Fact]
        public async Task DeleteCategoryAsync_LogsError_WhenCategoryNotFound()
        {
            // Arrange
            var categoryId = 1;

            _categoryRepositoryMock
                .Setup(repo => repo
                    .GetByIdAsync(It.IsAny<int>(), It.IsAny<string>()))
                .ReturnsAsync((ContentCategory)null);

            // Act
            await Assert.ThrowsAsync<NotFoundException>(() => _categoryService.DeleteCategoryAsync(categoryId));

            // Assert
            _categoryRepositoryMock.Verify(repo => repo.Delete(It.IsAny<ContentCategory>()), Times.Never);
            _categoryRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Never);
        }

        [Fact]
        public async Task DeleteCategoryAsync_LogsError_WhenSaveChangesFails()
        {
            // Arrange
            var categoryId = 1;

            _categoryRepositoryMock
                .Setup(repo => repo
                    .GetByIdAsync(It.IsAny<int>(), It.IsAny<string>()))
                .ReturnsAsync(new ContentCategory { Id = categoryId, Name = "Action" });

            _categoryRepositoryMock.Setup(repo => repo.SaveChangesAsync()).ThrowsAsync(new Exception());

            // Act
            await _categoryService.DeleteCategoryAsync(categoryId);

            // Assert
            _categoryRepositoryMock.Verify(repo => repo.Delete(It.IsAny<ContentCategory>()), Times.Once);
            _categoryRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);
            _loggerManagerMock.Verify(logger => logger
            .LogError($"Deleted category {categoryId} error {It.IsAny<string>()}"), Times.Once);
        }

        [Fact]
        public async Task GetCategoryAsync_ReturnsCorrectNumberOfCategories()
        {
            // Arrange
            var categories = new List<ContentCategory>
            {
                new ContentCategory { Id = 1, Name = "Category 1" },
                new ContentCategory { Id = 2, Name = "Category 2" },
                new ContentCategory { Id = 3, Name = "Category 3" }
            };
            var categoryParameters = new CategoryParameters();

            _categoryRepositoryMock
                .Setup(repo => repo
                    .GetAllAsync(
                    It.IsAny<CategoryParameters>(),
                        It.IsAny<Expression<Func<ContentCategory, bool>>>(),
                        It.IsAny<Func<IQueryable<ContentCategory>, IOrderedQueryable<ContentCategory>>>(),
                        It.IsAny<Func<IQueryable<ContentCategory>, IIncludableQueryable<ContentCategory, object>>>()))
                .ReturnsAsync(new PagedList<ContentCategory>(categories, categories.Count, 1, categories.Count));

            // Act
            var result = await _categoryService.GetCategoryAsync(categoryParameters);

            // Assert
            Assert.Equal(categories.Count, result.Count);
        }

        [Fact]
        public async Task GetCategoryByIdAsync_CategoryExists_ReturnsCategory()
        {
            // Arrange
            var categoryId = 1;
            var expectedCategory = new ContentCategory { Id = categoryId };
            _categoryRepositoryMock
                .Setup(repo => repo
                .GetByIdAsync(It.IsAny<int>(), It.IsAny<string>()))
                .ReturnsAsync(expectedCategory);

            // Act
            var result = await _categoryService.GetCategoryByIdAsync(categoryId);

            // Assert
            Assert.Equal(expectedCategory, result);
        }

        [Fact]
        public async Task UpdateCategoryAsync_ShouldUpdateCategoryAndLogSuccess()
        {
            // Arrange
            var category = new ContentCategory { Id = 1, Name = "Test Category" };

            _categoryRepositoryMock.Setup(x => x.Update(It.IsAny<ContentCategory>()));

            // Act
            await _categoryService.UpdateCategoryAsync(category);

            // Assert
            _categoryRepositoryMock.Verify(x => x.Update(category), Times.Once);
            _categoryRepositoryMock.Verify(x => x.SaveChangesAsync(), Times.Once);
            _loggerManagerMock.Verify(x => x.LogInfo($"Updated {category.Id}"), Times.Once);
        }
    }
}
