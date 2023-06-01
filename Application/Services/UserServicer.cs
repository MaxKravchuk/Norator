using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Paginator;
using Core.Paginator.Parameters;
using Core.ViewModels.UserViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IContentRepository _contentRepository;
        private readonly IContenService _contenService;
        private readonly IUser_ContentRepository _user_ContentRepository;
        private readonly ILoggerManager _loggerManager;

        public UserService(
            IUserRepository userRepository,
            IContenService contenService,
            IUser_ContentRepository user_ContentRepository,
            ILoggerManager loggerManager,
            IContentRepository contentRepository)
        {
            _userRepository = userRepository;
            _contenService = contenService;
            _user_ContentRepository = user_ContentRepository;
            _loggerManager = loggerManager;
            _contentRepository = contentRepository;
        }

        public async Task AddContent(int userId, int contentId)
        {
            var user = await GetUserByIdAsync(userId);
            var content = await _contentRepository.GetByIdAsync(contentId);

            user.User_Contents.Add(new User_Content()
            {
                Content = content,
                User = user
            });
            content.NumberOfSubscribers += 1;
            _contentRepository.Update(content);
            await _contentRepository.SaveChangesAsync();
            await _userRepository.SaveChangesAsync();
            _loggerManager.LogInfo($"Content {contentId} successful added to user {userId}");
        }

        public async Task DeleteContent(int userId, int contentId)
        {
            var userContent = await _user_ContentRepository.GetUserContentByUserAndContentId(userId, contentId);
            var content = await _contentRepository.GetByIdAsync(contentId);
            if (userContent == null)
            {
                throw new NotFoundException();
            }

            content.NumberOfSubscribers -= 1;
            _contentRepository.Update(content);
            await _contentRepository.SaveChangesAsync();
            _user_ContentRepository.Delete(userContent);
            await _user_ContentRepository.SaveChangesAsync();
            _loggerManager.LogInfo($"Content {contentId} successful deleted to user {userId}");
        }

        public async Task<int> CreateUserAsync(User user)
        {
            user.UserType = Core.Enums.UserType.Client;
            await _userRepository.InsertAsync(user);

            await _userRepository.SaveChangesAsync();
            _loggerManager.LogInfo($"Created user successfuly: {user.NickName}");

            var id = user.Id;
            return id;
        }

        public async Task DeleteUserAsync(int id)
        {
            var userToDelete = await GetUserByIdAsync(id);
            _userRepository.Delete(userToDelete);
            await _userRepository.SaveChangesAsync();
            _loggerManager.LogInfo($"User {id} deleted");
        }

        public async Task<PagedList<User>> GetUsersAsync(UserParameters userParameters)
        {
            var filterQuery = GetFilterQuery(userParameters.FilterParam);

            var users = await _userRepository.GetAllAsync(
                userParameters,
                filterQuery);

            _loggerManager.LogInfo($"Fetched {users.Count} users");

            return users;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id,
                includeProperties: "User_Contents.Content,User_Contents.Content.ContentCategory");

            if (user == null)
            {
                _loggerManager.LogError($"User with id {id} is null");
                throw new NotFoundException();
            }
            _loggerManager.LogInfo($"Getted user with {user.Id}");
            return user;
        }

        public async Task UpdateUserAsync(User user)
        {
            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
            _loggerManager.LogInfo($"Updated user: {user.Id}");
        }

        public async Task<User> LogInAsync(UserLogInViewModel model)
        {
            if (model == null)
            {
                throw new ForbidException();
            }

            var filter = GetFilterLogInQuery(model.NickName, model.Password);

            var users = await _userRepository.GetAsync(
                filter: filter,
                includeProperties: "User_Contents.Content,User_Contents.Content.ContentCategory",
                asNoTracking: true);

            if (users.Any() && users != null)
            {
                _loggerManager.LogInfo($"User {model.NickName} is logged in");
                return users.SingleOrDefault();
            }
            else
            {
                _loggerManager.LogError($"Error while loggining for user {model.NickName}");
                throw new ForbidException();
            }
        }

        private static Expression<Func<User, bool>>? GetFilterQuery(string? filterParam)
        {
            Expression<Func<User, bool>>? filterQuery = null;

            if (filterParam is not null)
            {
                string formatedFilter = filterParam.Trim().ToLower();

                filterQuery = u => u.NickName!.ToLower().Contains(formatedFilter);
            }

            return filterQuery;
        }

        private static Expression<Func<User, bool>>? GetFilterLogInQuery(string? nick, string? passwd)
        {
            Expression<Func<User, bool>>? filterQuery = null;

            if (nick is not null && passwd is not null)
            {
                string Fnick = nick.Trim().ToLower();
                string Fpasswd = passwd.Trim().ToLower();


                filterQuery = u => u.NickName!.ToLower()==(Fnick) && u.Password!.ToLower()==(Fpasswd);
            }

            return filterQuery;
        }
    }
}
