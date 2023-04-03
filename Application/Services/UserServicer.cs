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
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IContenService _contenService;
        private readonly IUser_ContentRepository _user_ContentRepository;

        public UserService(
            IUserRepository userRepository,
            IContenService contenService,
            IUser_ContentRepository user_ContentRepository)
        {
            _userRepository = userRepository;
            _contenService = contenService;
            _user_ContentRepository = user_ContentRepository;

        }

        public async Task AddContent(int userId, int contentId)
        {
            var user = await GetUserByIdAsync(userId);

            user.User_Contents.Add(new User_Content()
            {
                Content = await _contenService.GetContentByIdAsync(contentId),
                User = user
            });

            await _userRepository.SaveChangesAsync();
        }

        public async Task DeleteContent(int userId, int contentId)
        {
           var content = await _user_ContentRepository.GetUserContentByUserAndContentId(userId, contentId);
            if(content == null)
            {
                throw new NotFoundException();
            }
            _user_ContentRepository.Delete(content);
            await _user_ContentRepository.SaveChangesAsync();
        }

        public async Task<int> CreateUserAsync(User user)
        {
            user.UserType = Core.Enums.UserType.Client;
            await _userRepository.InsertAsync(user);
            await _userRepository.SaveChangesAsync();
            var id = user.Id;
            return id;
        }

        public async Task DeleteUserAsync(int id)
        {
            var userToDelete = await GetUserByIdAsync(id);
            _userRepository.Delete(userToDelete);
            await _userRepository.SaveChangesAsync();
        }

        public async Task<PagedList<User>> GetUsersAsync(UserParameters userParameters)
        {
            var filterQuery = GetFilterQuery(userParameters.FilterParam);

            var users = await _userRepository.GetAllAsync(
                userParameters,
                filterQuery);

            return users;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id,
                includeProperties: "User_Contents.Content,User_Contents.Content.ContentCategory");

            if (user == null)
            {
                throw new NotFoundException();
            }

            return user;
        }

        public async Task UpdateUserAsync(User user)
        {
            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
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
                return users.SingleOrDefault();
            }
            else
            {
                throw new ForbidException();
            }
        }

        private static Expression<Func<User, bool>>? GetFilterQuery(string? filterParam)
        {
            Expression<Func<User, bool>>? filterQuery = null;

            if (filterParam is not null)
            {
                string formatedFilter = filterParam.Trim().ToLower();

                filterQuery = u => u.NickName!.ToLower().Contains(formatedFilter)
                                    || u.User_Contents.Any(x=>x.Content.Name.ToLower()==filterParam.ToLower());
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


                filterQuery = u => u.NickName!.ToLower().Contains(Fnick) && u.Password!.ToLower().Contains(Fpasswd);
            }

            return filterQuery;
        }
    }
}
