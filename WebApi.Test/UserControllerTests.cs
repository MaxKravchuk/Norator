using Core.Entities;
using Core.Interfaces.Services;
using Core.Paginator;
using Core.ViewModels.UserViewModels;
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
    public class UserControllerTests
    {
        private readonly Mock<IUserService> _userServiceMock;
        private readonly Mock<IViewModelMapper<UserCreateViewModel, User>> _createMapperMock;
        private readonly Mock<IEnumerableViewModelMapper<IEnumerable<User>, IEnumerable<UserReadListViewModel>>> _listReadMapperMock;
        private readonly Mock<IViewModelMapper<PagedList<User>, PagedReadViewModel<UserReadListViewModel>>> _pagedMapperMock;
        private readonly Mock<IViewModelMapper<User, UserReadViewModel>> _readMapperMock;
        private readonly Mock<IViewModelMapper<UserUpdateViewModel, User>> _updateMapperMock;
        private readonly Mock<IViewModelMapper<User, UserReadListViewModel>> _logInMapperMock;
        private readonly UserController _userController;

        public UserControllerTests()
        {
            _userServiceMock = new Mock<IUserService>();
            _createMapperMock = new Mock<IViewModelMapper<UserCreateViewModel, User>>();
            _listReadMapperMock = new Mock<IEnumerableViewModelMapper<IEnumerable<User>, IEnumerable<UserReadListViewModel>>>();
            _pagedMapperMock = new Mock<IViewModelMapper<PagedList<User>, PagedReadViewModel<UserReadListViewModel>>>();
            _readMapperMock = new Mock<IViewModelMapper<User, UserReadViewModel>>();
            _updateMapperMock = new Mock<IViewModelMapper<UserUpdateViewModel, User>>();
            _logInMapperMock = new Mock<IViewModelMapper<User, UserReadListViewModel>>();
            _userController = new UserController(
                _userServiceMock.Object,
                _createMapperMock.Object,
                _listReadMapperMock.Object,
                _pagedMapperMock.Object,
                _readMapperMock.Object,
                _updateMapperMock.Object,
                _logInMapperMock.Object);
        }

        [Fact]
        public async Task GetAsync_WhenCalled_ReturnsPagedReadViewModel()
        {
            // Arrange
            var userParameters = new UserParameters();
            var users = new PagedList<User>(new List<User>(), 1, 1, 1);
            var viewModel = new PagedReadViewModel<UserReadListViewModel>();

            _userServiceMock.Setup(x => x.GetUsersAsync(It.IsAny<UserParameters>())).ReturnsAsync(users);
            
            _pagedMapperMock.Setup(x => x.Map(It.IsAny<PagedList<User>>())).Returns(viewModel);
            
            // Act
            var result = await _userController.GetAsync(userParameters);
            
            // Assert
            Assert.Equal(viewModel, result);
        }

        [Fact]
        public async Task GetAsync_WhenCalled_ReturnsUserReadViewModel()
        {
            // Arrange
            var id = 1;
            var user = new User();
            var viewModel = new UserReadViewModel();

            _userServiceMock.Setup(x => x.GetUserByIdAsync(It.IsAny<int>())).ReturnsAsync(user);
            
            _readMapperMock.Setup(x => x.Map(It.IsAny<User>())).Returns(viewModel);
            
            // Act
            var result = await _userController.GetAsync(id);
            
            // Assert
            Assert.Equal(viewModel, result);
        }

        [Fact]
        public async Task CreateUser_WhenCalled_ReturnsUserReadViewModel()
        {
            // Arrange
            var viewModel = new UserCreateViewModel();
            var user = new User();
            var resultViewModel = new UserReadViewModel();

            _createMapperMock.Setup(x => x.Map(It.IsAny<UserCreateViewModel>())).Returns(user);
            
            _userServiceMock.Setup(x => x.CreateUserAsync(It.IsAny<User>())).Verifiable();
            
            _readMapperMock.Setup(x => x.Map(user)).Returns(resultViewModel);
            
            // Act
            var result = await _userController.CreateUser(viewModel);
            
            // Assert
            Assert.Equal(resultViewModel.Id, result);
        }

        [Fact]
        public async Task UpdateUser_WhenCalled_ReturnsUserReadViewModel()
        {
            // Arrange
            var viewModel = new UserUpdateViewModel();
            var user = new User();
            var resultViewModel = new UserReadViewModel();

            _updateMapperMock.Setup(x => x.Map(It.IsAny<UserUpdateViewModel>())).Returns(user);
            
            _userServiceMock.Setup(x => x.UpdateUserAsync(It.IsAny<User>())).Verifiable();
            
            _readMapperMock.Setup(x => x.Map(user)).Returns(resultViewModel);
            
            // Act
            await _userController.UpdateUser(viewModel);
            
            // Assert
            _userServiceMock.Verify(s=>s.UpdateUserAsync(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task DeleteUser_WhenCalled_ReturnsUserReadViewModel()
        {
            // Arrange
            var id = 1;
            var user = new User();
            var resultViewModel = new UserReadViewModel();

            
            _userServiceMock.Setup(x => x.DeleteUserAsync(It.IsAny<int>())).Verifiable();
            
            // Act
            await _userController.DeleteUser(id);
            
            // Assert
            _userServiceMock.Verify(s=>s.DeleteUserAsync(id), Times.Once);
        }

        [Fact]
        public async Task LogIn_WhenCalled_ReturnsUserReadViewModel()
        {
            // Arrange
            var viewModel = new UserLogInViewModel();
            var user = new User();
            var resultViewModel = new UserReadListViewModel();

            _userServiceMock.Setup(x => x.LogInAsync(It.IsAny<UserLogInViewModel>())).ReturnsAsync(user);
            
            _logInMapperMock.Setup(x => x.Map(user)).Returns(resultViewModel);
            
            // Act
            var result = await _userController.LogIn(viewModel);
            
            // Assert
            Assert.Equal(resultViewModel, result);
        }

        [Fact]
        public async Task AddContent_ShouldAdd()
        {
            // Arrange
            var userAddContentViewModel = new UserAddContentViewModel();

            _userServiceMock.Setup(x => x.AddContent(It.IsAny<int>(), It.IsAny<int>())).Verifiable();

            // Act
            await _userController.AddContent(userAddContentViewModel);

            // Assert
            _userServiceMock.Verify(s => s.AddContent(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task RemoveContent_ShouldRemove()
        {
            // Arrange
            var userRemoveContentViewModel = new UserAddContentViewModel();

            _userServiceMock.Setup(x => x.DeleteContent(It.IsAny<int>(), It.IsAny<int>())).Verifiable();
            
            // Act
            await _userController.DeleteContent(userRemoveContentViewModel);
            
            // Assert
            _userServiceMock.Verify(s => s.DeleteContent(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
    }
}
