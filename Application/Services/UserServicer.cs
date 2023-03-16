using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task CreateUserAsync(User user)
        {
            await _userRepository.InsertAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var userToDelete = await GetUserByIdAsync(id);
            _userRepository.Delete(userToDelete);
            await _userRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetUserAsync()
        {
            var users = await _userRepository.GetAsync(
                includeProperties: "User_Contents.Content");

            return users;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                throw new NotFoundException();
            }

            return user;
        }

        public async Task<User> GetUserByNameAsync(string name)
        {
            var user = await _userRepository.GetByNameAsync(name);

            if (user == null)
            {
                throw new NotFoundException();
            }

            return user;
        }

        public async Task UpdateUserAsync(User user, IEnumerable<int> contentsId)
        {
            var exContent = await _user_ContentRepository.GetAsync(
                filter: con => con.UserId == user.Id);
            foreach (var content in exContent)
            {
                _user_ContentRepository.Delete(content);
            }

            foreach (var contentId in contentsId)
            {
                user.User_Contents.Add(new User_Content()
                {
                    User = user,
                    Content = await _contenService.GetContentByIdAsync(contentId)
                });
            }
            await _user_ContentRepository.SaveChangesAsync();

            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
        }


    }
}
