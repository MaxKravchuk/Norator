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
                    .GetAsync(
                        It.IsAny<Expression<Func<ContentCategory, bool>>>(),
                        It.IsAny<Func<IQueryable<ContentCategory>, IOrderedQueryable<ContentCategory>>>(),
                        It.IsAny<string>(),
                        It.IsAny<bool>()))
                .ReturnsAsync(categories);

            // Act
            var result = await _categoryService.GetCategoryAsync();

            // Assert
            Assert.Equal(categories.Count, result.Count());
        }
    }
}
