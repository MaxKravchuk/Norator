using Core.Entities;
using Core.Paginator.Parameters;
using Core.Paginator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.ViewModels.UserViewModels;

namespace Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int id);
        Task<PagedList<User>> GetUsersAsync(UserParameters actorParameters);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task AddContent(int userId, int contentId);
        Task DeleteContent(int userId, int contentId);
        Task<User> LogInAsync(UserLogInViewModel model);
    }
}
