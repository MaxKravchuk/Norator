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
    public class ActorServiceTests
    {
        private readonly Mock<IActorRepository> _actorRepositoryMock;
        private readonly Mock<ILoggerManager> _loggerManagerMock;
        private readonly ActorService _actorService;

        public ActorServiceTests()
        {
            _actorRepositoryMock = new Mock<IActorRepository>();
            _loggerManagerMock = new Mock<ILoggerManager>();
            _actorService = new ActorService(
                _actorRepositoryMock.Object,
                _loggerManagerMock.Object);
        }

        [Fact]
        public async Task CreateActorAsync_WithCorrectModel_ShouldCreateAndLog()
        {
            // Assert
            var actor = new Actor();

            _actorRepositoryMock
                .Setup(r => r
                    .InsertAsync(It.IsAny<Actor>()))
                .Verifiable();

            // Act
            await _actorService.CreateActorAsync(actor);

            // Assert
            _loggerManagerMock.Verify(l => l
                .LogInfo($"Adding actor {actor.Name} successful"), Times.Once);
            _actorRepositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteActorAsync_WithCorrectId_ShouldDelete()
        {
            // Assert
            var id = 1;
            var actor = new Actor() { Id = 1 };

            _actorRepositoryMock
                .Setup(r => r
                    .GetByIdAsync(
                        It.IsAny<int>(),
                        It.IsAny<string>()))
                .ReturnsAsync(actor);

            // Act
            await _actorService.DeleteActorAsync(id);

            // Assert
            _actorRepositoryMock.Verify(repo => repo.Delete(actor), Times.Once);
            _actorRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);
            _loggerManagerMock.Verify(logger => logger.LogInfo($"Deleting actor {actor.Name} successful"), Times.Once);
        }

        [Fact]
        public async Task GetActorByIdAsync_ExistingActor_ReturnsActor()
        {
            // Arrange
            var actorId = 1;
            var actorToReturn = new Actor { Id = actorId };

            _actorRepositoryMock
                .Setup(repo => repo
                    .GetByIdAsync(
                        It.IsAny<int>(),
                        It.IsAny<string>()))
                .ReturnsAsync(actorToReturn);

            // Act
            var result = await _actorService.GetActorByIdAsync(actorId);

            // Assert
            Assert.Equal(actorToReturn, result);
            _loggerManagerMock.Verify(logger => logger.LogInfo($"Getting actor {actorId} successful"), Times.Once);
            _actorRepositoryMock.Verify(repo => repo.GetByIdAsync(actorId, "Content_Actors.Content"), Times.Once);
        }

        [Fact]
        public async Task GetActorByIdAsync_NonExistingActor_ThrowsNotFoundException()
        {
            // Arrange
            var actorId = 1;
            Actor? actor = null;

            _actorRepositoryMock
                .Setup(repo => repo
                    .GetByIdAsync(
                        It.IsAny<int>(),
                        It.IsAny<string>()))
                .ReturnsAsync(actor);

            // Act and assert
            await Assert.ThrowsAsync<NotFoundException>(() => _actorService.GetActorByIdAsync(actorId));
            _loggerManagerMock.Verify(logger => logger.LogError($"Failed to find {actorId} actor"), Times.Once);
        }

        [Fact]
        public async Task GetActorsAsync_ReturnsPagedListWithCorrectNumberOfActors()
        {
            // Arrange
            var actorParameters = new ActorParameters();
            var actorsToReturn = new List<Actor>
            {
                new Actor { Id = 1},
                new Actor { Id = 2},
                new Actor { Id = 3},
                new Actor { Id = 4},
            };

            _actorRepositoryMock
                .Setup(repo => repo
                    .GetAllAsync(
                        It.IsAny<ActorParameters>(),
                        It.IsAny<Expression<Func<Actor, bool>>>(),
                        It.IsAny<Func<IQueryable<Actor>, IOrderedQueryable<Actor>>>(),
                        It.IsAny<Func<IQueryable<Actor>, IIncludableQueryable<Actor, object>>>()))
                .ReturnsAsync(new PagedList<Actor>(actorsToReturn, actorsToReturn.Count, 1, actorsToReturn.Count));


            // Act
            var result = await _actorService.GetActorsAsync(actorParameters);

            // Assert
            Assert.Equal(actorsToReturn.Count, result.Count);
            _actorRepositoryMock.Verify(repo => repo
                .GetAllAsync(
                    actorParameters,
                    It.IsAny<Expression<Func<Actor, bool>>>(),
                    It.IsAny<Func<IQueryable<Actor>, IOrderedQueryable<Actor>>>(),
                    It.IsAny<Func<IQueryable<Actor>, IIncludableQueryable<Actor, object>>>()), Times.Once);
            _loggerManagerMock.Verify(logger => logger.LogInfo($"Getting {actorsToReturn.Count} actors"), Times.Once);
        }

        [Fact]
        public async Task UpdateActorAsync_UpdatesActorAndLogsInfo()
        {
            // Arrange
            var actorToUpdate = new Actor { Id = 1 };

            // Act
            await _actorService.UpdateActorAsync(actorToUpdate);

            // Assert
            _actorRepositoryMock.Verify(repo => repo.Update(actorToUpdate), Times.Once);
            _actorRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);
            _loggerManagerMock.Verify(logger => logger.LogError($"Updating actor {actorToUpdate.Name} successful"), Times.Once);
        }

        [Fact]
        public async Task UpdateActorAsync_LogsError_WhenUpdateFails()
        {
            // Arrange
            var actorToUpdate = new Actor { Id = 1 };

            _actorRepositoryMock
                .Setup(repo => repo
                    .SaveChangesAsync()).ThrowsAsync(new Exception());

            // Act
            var result = _actorService.UpdateActorAsync(actorToUpdate);

            // Assert
            await Assert.ThrowsAsync<Exception>(() => result);
        }
    }
}
