using Core.Entities;
using Core.Interfaces.Services;
using Core.Paginator;
using Core.Paginator.Parameters;
using Core.ViewModels;
using Core.ViewModels.ActorViewModels;
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
    public class ActorControllerTests
    {
        private readonly Mock<IActorService> _actorServiceMock;
        private readonly Mock<IViewModelMapper<ActorCreateViewModel, Actor>> _actorCreateVMMock;
        private readonly Mock<IViewModelMapper<ActorUpdateViewModel, Actor>> _actorUpdateVMMock;
        private readonly Mock<IViewModelMapper<Actor, ActorReadViewModel>> _actorVMMapperMock;
        private readonly Mock<IViewModelMapper<PagedList<Actor>, PagedReadViewModel<ActorListReadViewModel>>> _pagedListMapperMock;
        private readonly ActorController _actorController;

        public ActorControllerTests()
        {
            _actorServiceMock = new Mock<IActorService>();
            _actorCreateVMMock = new Mock<IViewModelMapper<ActorCreateViewModel, Actor>>();
            _actorUpdateVMMock = new Mock<IViewModelMapper<ActorUpdateViewModel, Actor>>();
            _actorVMMapperMock = new Mock<IViewModelMapper<Actor, ActorReadViewModel>>();
            _pagedListMapperMock = new Mock<IViewModelMapper<PagedList<Actor>, PagedReadViewModel<ActorListReadViewModel>>>();
            
            _actorController = new ActorController(
                _actorServiceMock.Object,
                _actorCreateVMMock.Object,
                _actorUpdateVMMock.Object,
                _actorVMMapperMock.Object,
                _pagedListMapperMock.Object
            );
        }

        [Fact]
        public async Task GetAsync_Returns_PagedReadViewModel()
        {
            // Arrange
            var actorParameters = new ActorParameters();
            var listOfActors = new PagedList<Actor>(new List<Actor>(), 1, 10, 0);
            var pagedReadViewModel = new PagedReadViewModel<ActorListReadViewModel>();

            _actorServiceMock
                .Setup(service => service
                    .GetActorsAsync(It.IsAny<ActorParameters>()))
                .ReturnsAsync(listOfActors);

            _pagedListMapperMock
                .Setup(mapper => mapper
                    .Map(It.IsAny<PagedList<Actor>>()))
                .Returns(pagedReadViewModel);

            // Act
            var result = await _actorController.GetAsync(actorParameters);

            // Assert
            Assert.IsType<PagedReadViewModel<ActorListReadViewModel>>(result);
            Assert.Null(result.Entities);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnActor()
        {
            // Arrange
            var actor = new Actor();
            var actorReadViewModel = new ActorReadViewModel();

            _actorServiceMock
                .Setup(service => service
                    .GetActorByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(actor);

            _actorVMMapperMock
                .Setup(mapper => mapper
                    .Map(It.IsAny<Actor>()))
                .Returns(actorReadViewModel);

            // Act
            var result = await _actorController.GetByIdAsync(1);

            // Assert
            Assert.IsType<ActorReadViewModel>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CreateActorAsync_ShouldCreate()
        {
            // Arrange
            var actorCreateViewModel = new ActorCreateViewModel();
            var actor = new Actor();
            
            _actorCreateVMMock
                .Setup(mapper => mapper
                    .Map(It.IsAny<ActorCreateViewModel>()))
                .Returns(actor);

            _actorServiceMock
                .Setup(s => s.
                    CreateActorAsync(It.IsAny<Actor>())).Verifiable();
            // Act
            await _actorController.CreateAsync(actorCreateViewModel);
            // Assert
            _actorServiceMock.Verify(s => s.CreateActorAsync(actor), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdate()
        {
            // Arrange
            var actorUpdateViewModel = new ActorUpdateViewModel();
            var actor = new Actor();

            _actorUpdateVMMock
                .Setup(mapper => mapper
                    .Map(It.IsAny<ActorUpdateViewModel>()))
                .Returns(actor);

            _actorServiceMock
                .Setup(s => s
                .   UpdateActorAsync(It.IsAny<Actor>())).Verifiable();
            // Act
            await _actorController.UpdateAsync(actorUpdateViewModel);
            // Assert
            _actorServiceMock.Verify(s => s.UpdateActorAsync(actor), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldDelete()
        {
            // Arrange
            _actorServiceMock
                .Setup(s => s
                .DeleteActorAsync(It.IsAny<int>())).Verifiable();
            // Act
            await _actorController.DeleteAsync(1);
            // Assert
            _actorServiceMock.Verify(s => s.DeleteActorAsync(1), Times.Once);
        }

    }
}
