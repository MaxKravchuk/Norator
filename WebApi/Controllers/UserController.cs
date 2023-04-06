using Core.Entities;
using Core.Interfaces.Services;
using Core.Paginator;
using Core.Paginator.Parameters;
using Core.ViewModels;
using Core.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.AutoMapper.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IViewModelMapper<UserCreateViewModel, User> _createMapper;
        private readonly IEnumerableViewModelMapper<IEnumerable<User>, IEnumerable<UserReadListViewModel>> _listReadMapper;
        private readonly IViewModelMapper<PagedList<User>, PagedReadViewModel<UserReadListViewModel>> _pagedMapper;
        private readonly IViewModelMapper<User, UserReadViewModel> _readMapper;
        private readonly IViewModelMapper<UserUpdateViewModel, User> _updateMapper;
        private readonly IViewModelMapper<User, UserReadListViewModel> _logInMapper;

        public UserController(
            IUserService userService,
            IViewModelMapper<UserCreateViewModel, User> createMapper,
            IEnumerableViewModelMapper<IEnumerable<User>, IEnumerable<UserReadListViewModel>> listReadMapper,
            IViewModelMapper<PagedList<User>, PagedReadViewModel<UserReadListViewModel>> pagedMapper,
            IViewModelMapper<User, UserReadViewModel> readMapper,
            IViewModelMapper<UserUpdateViewModel, User> updateMapper,
            IViewModelMapper<User, UserReadListViewModel> logInMapper)
        {
            _userService = userService;
            _createMapper = createMapper;
            _listReadMapper = listReadMapper;
            _pagedMapper = pagedMapper;
            _readMapper = readMapper;
            _updateMapper = updateMapper;
            _logInMapper = logInMapper;
        }

        [HttpGet("getall")]
        public async Task<PagedReadViewModel<UserReadListViewModel>> GetAsync([FromQuery] UserParameters userParameters)
        {
            var users = await _userService.GetUsersAsync(userParameters);
            var viewModel = _pagedMapper.Map(users);
            return viewModel;
        }

        [HttpGet("{id:int:min(1)}")]
        public async Task<UserReadViewModel> GetAsync([FromRoute] int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            var viewModel = _readMapper.Map(user);
            return viewModel;
        }

        [HttpPost("createUser")]
        public async Task<int> CreateUser([FromBody] UserCreateViewModel viewModel)
        {
            var user = _createMapper.Map(viewModel);
            var id = await _userService.CreateUserAsync(user);
            return id;
        }

        [HttpPut]
        public async Task UpdateUser([FromBody] UserUpdateViewModel viewModel)
        {
            var user = _updateMapper.Map(viewModel);
            await _userService.UpdateUserAsync(user);
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task DeleteUser([FromRoute] int id)
        {
            await _userService.DeleteUserAsync(id);
        }

        [HttpPost("addContent")]
        public async Task AddContent([FromBody] UserAddContentViewModel userAddContentViewModel)
        {
            await _userService.AddContent(userAddContentViewModel.userId, userAddContentViewModel.contentId);
        }

        [HttpGet("login")]
        public async Task<UserReadListViewModel> LogIn([FromQuery] UserLogInViewModel userLogIn)
        {
            var user = await _userService.LogInAsync(userLogIn);
            var viewModel = _logInMapper.Map(user);
            return viewModel;
        }
    }
}
