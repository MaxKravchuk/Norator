using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Application.Services;
using Xunit;
using Core.Entities;
using Core.ViewModels.UserViewModels;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Test
{
    public class UserServicerTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IContenService> _contenServiceMock;
        private readonly Mock<IUser_ContentRepository> _userContentRepositoryMock;
        private readonly Mock<ILoggerManager> _loggerManagerMock;
        private readonly UserService _userService;

        public UserServicerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _contenServiceMock = new Mock<IContenService>();
            _userContentRepositoryMock = new Mock<IUser_ContentRepository>();
            _loggerManagerMock = new Mock<ILoggerManager>();
            _userService = new UserService(
                _userRepositoryMock.Object,
                _contenServiceMock.Object,
                _userContentRepositoryMock.Object,
                _loggerManagerMock.Object);
        }

        [Fact]
        public async Task AddContent_ShouldAdd()
        {
            //Arrange
            var userId = 1;
            var contentId = 2;
            var user = new User { Id = userId };
            var content = new Content { Id = contentId };

            _userRepositoryMock
                .Setup(x => x
                    .GetByIdAsync(It.IsAny<int>(),It.IsAny<string>())).ReturnsAsync(user);

            _contenServiceMock.Setup(x => x.GetContentByIdAsync(contentId)).ReturnsAsync(content);

            //Act
            await _userService.AddContent(userId, contentId);

            //Assert
            _userRepositoryMock.Verify(x => x.SaveChangesAsync(), Times.Once);
            _loggerManagerMock.Verify(x => x.LogInfo($"Content {contentId} successful added to user {userId}"), Times.Once);
        }

        [Fact]
        public async Task DeleteContent_ShouldDelete()
        {
            // Arrange
            var userId = 1;
            var contentId = 1;
            var mockUserContent = new User_Content { UserId = userId, ContentId = contentId };

            _userContentRepositoryMock
                .Setup(x => x
                    .GetUserContentByUserAndContentId(userId, contentId)).ReturnsAsync(mockUserContent);

            // Act
            await _userService.DeleteContent(userId, contentId);

            // Assert
            _userContentRepositoryMock.Verify(x => x.Delete(mockUserContent), Times.Once);
            _userContentRepositoryMock.Verify(x => x.SaveChangesAsync(), Times.Once);
            _loggerManagerMock.Verify(x => x.LogInfo($"Content {contentId} successful deleted to user {userId}"), Times.Once);
        }

        [Fact]
        public async Task Create_ShouldCreate()
        {
            // Arrange
            var user = new User { NickName = "Test User" };

            _userRepositoryMock.Setup(x => x.InsertAsync(user)).Callback(() => user.Id = 1);

            // Act
            var result = await _userService.CreateUserAsync(user);

            // Assert
            _userRepositoryMock.Verify(x => x.InsertAsync(user), Times.Once);
            _userRepositoryMock.Verify(x => x.SaveChangesAsync(), Times.Once);
            _loggerManagerMock.Verify(x => x.LogInfo($"Created user successfuly: {user.NickName}"), Times.Once);
            Assert.Equal(1, result);
        }

        [Fact]
        public async Task Delete_ShouldDelete()
        {
            // Arrange
            var userToDelete = new User { Id = 1, NickName = "Test User" };

            _userRepositoryMock
                .Setup(x => x
                    .GetByIdAsync(It.IsAny<int>(),It.IsAny<string>())).ReturnsAsync(userToDelete);

            _userRepositoryMock.Setup(x => x.Delete(userToDelete)).Verifiable();

            // Act
            await _userService.DeleteUserAsync(userToDelete.Id);

            // Assert
            _userRepositoryMock.Verify(x => x.Delete(userToDelete), Times.Once);
            _userRepositoryMock.Verify(x => x.SaveChangesAsync(), Times.Once);
            _loggerManagerMock.Verify(x => x.LogInfo($"User {userToDelete.Id} deleted"), Times.Once);
        }

        [Fact]
        public async Task Update_ShouldUpdate()
        {
            // Arrange
            var userToUpdate = new User { Id = 1, NickName = "Test User" };

            _userRepositoryMock.Setup(x => x.Update(userToUpdate));

            // Act
            await _userService.UpdateUserAsync(userToUpdate);

            // Assert
            _userRepositoryMock.Verify(x => x.Update(userToUpdate), Times.Once);
            _userRepositoryMock.Verify(x => x.SaveChangesAsync(), Times.Once);
            _loggerManagerMock.Verify(x => x.LogInfo($"Updated user: {userToUpdate.Id}"), Times.Once);
        }

        [Fact]
        public async Task LogIn_ShouldLogIn()
        {
            // Arrange
            var userLogInViewModel = new UserLogInViewModel { NickName = "Test User", Password = "password123" };
            var users = new List<User> { new User { Id = 1, NickName = "Test User", Password = "password123" } };

            _userRepositoryMock
                .Setup(x => x
                    .GetAsync(
                        It.IsAny<Expression<Func<User, bool>>>(),
                        It.IsAny<Func<IQueryable<User>, IOrderedQueryable<User>>>(),
                        It.IsAny<string>(),
                        It.IsAny<bool>()))
                    .ReturnsAsync(users);

            // Act
            var result = await _userService.LogInAsync(userLogInViewModel);

            // Assert
            _userRepositoryMock.Verify(x => x.GetAsync(It.IsAny<Expression<Func<User, bool>>>(),
                        It.IsAny<Func<IQueryable<User>, IOrderedQueryable<User>>>(),
                        It.IsAny<string>(),
                        It.IsAny<bool>()), Times.Once);
            _loggerManagerMock.Verify(x => x.LogInfo($"User {userLogInViewModel.NickName} is logged in"), Times.Once);
            Assert.Equal(1, result.Id);
            Assert.Equal("Test User", result.NickName);
        }
    }
}
