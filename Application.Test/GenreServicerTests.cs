using Application.Services;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Paginator;
using Core.Paginator.Parameters;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.Test
{
    public class GenreServicerTests
    {
        private readonly Mock<IGenreRepository> _genreRepositoryMock;
        private readonly Mock<ILoggerManager> _loggerManagerMock;
        private readonly GenreService _genreService;

        public GenreServicerTests()
        {
            _genreRepositoryMock = new Mock<IGenreRepository>();
            _loggerManagerMock = new Mock<ILoggerManager>();
            _genreService = new GenreService(
                _genreRepositoryMock.Object,
                _loggerManagerMock.Object);
        }

        [Fact]
        public async Task CreateGenreAsync_ShouldCreateGenre()
        {
            // Arrange
            var genre = new Genre { Name = "Action" };

            _genreRepositoryMock.Setup(repo => repo.InsertAsync(It.IsAny<Genre>()))
                .Callback<Genre>(genre => genre.Id = 1);

            // Act
            await _genreService.CreateGenreAsync(genre);

            // Assert
            _genreRepositoryMock.Verify(repo => repo.InsertAsync(It.IsAny<Genre>()), Times.Once);
            _genreRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);
            _loggerManagerMock.Verify(logger => logger.LogInfo(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task DeleteGenreAsync_ShouldDeleteGenre_WhenGenreExists()
        {
            // Arrange
            var genre = new Genre { Name = "Test Genre" };

            _genreRepositoryMock
                .Setup(repo => repo.GetByIdAsync(It.IsAny<int>(), It.IsAny<string>()))
                .ReturnsAsync(genre);

            _genreRepositoryMock
                .Setup(repo => repo.Delete(It.IsAny<Genre>())).Verifiable();

            // Act
            await _genreService.DeleteGenreAsync(genre.Id);

            // Assert
            _genreRepositoryMock.Verify(repo => repo.GetByIdAsync(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
            _genreRepositoryMock.Verify(repo => repo.Delete(It.IsAny<Genre>()), Times.Once);
            _genreRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task GetGenreAsync_ShouldReturnGenres()
        {
            // Arrange
            var genres = new PagedList<Genre>(new List<Genre>(),1,1,1);
            var genreParams = new GenreParameters();

            _genreRepositoryMock
                .Setup(x => x
                    .GetAllAsync(
                        It.IsAny<GenreParameters>(),
                        It.IsAny<Expression<Func<Genre, bool>>>(),
                        It.IsAny<Func<IQueryable<Genre>, IOrderedQueryable<Genre>>>(),
                        It.IsAny<Func<IQueryable<Genre>, IIncludableQueryable<Genre, object>>>()))
                .ReturnsAsync(genres);

            // Act
            var result = await _genreService.GetGenreAsync(genreParams);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<PagedList<Genre>>(result);
        }

        [Fact]
        public async Task GetGenreByIdAsync_Should_Return_Genre_When_Genre_Exists()
        {
            // Arrange
            var expectedGenre = new Genre { Id = 1, Name = "Action" };
            _genreRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>(), It.IsAny<string>()))
                .ReturnsAsync(expectedGenre);

            // Act
            var result = await _genreService.GetGenreByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedGenre.Id, result.Id);
            Assert.Equal(expectedGenre.Name, result.Name);
            _loggerManagerMock.Verify(x => x.LogInfo($"Getted genre with id {expectedGenre.Id}"), Times.Once);
            _loggerManagerMock.Verify(x => x.LogError(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task UpdateGenreAsync_Should_Update_Genre_When_Genre_Exists()
        {
            // Arrange
            var genreToUpdate = new Genre { Id = 1, Name = "Action" };

            // Act
            await _genreService.UpdateGenreAsync(genreToUpdate);

            // Assert
            _genreRepositoryMock.Verify(x => x.Update(genreToUpdate), Times.Once);
            _genreRepositoryMock.Verify(x => x.SaveChangesAsync(), Times.Once);
            _loggerManagerMock.Verify(x => x.LogInfo($"Genre with id {genreToUpdate.Id} updated successfully"), Times.Once);
            _loggerManagerMock.Verify(x => x.LogError(It.IsAny<string>()), Times.Never);
        }
    }
}
