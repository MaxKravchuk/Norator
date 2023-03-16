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

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
                throw new NotFoundExeption();
            }

            return user;
        }

        public async Task<User> GetUserByNameAsync(string name)
        {
            var user = await _userRepository.GetByNameAsync(name);

            if (user == null)
            {
                throw new NotFoundExeption();
            }

            return user;
        }

        public async Task UpdateUserAsync(User user)
        {
            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
        }
    }
}
