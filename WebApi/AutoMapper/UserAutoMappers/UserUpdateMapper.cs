using Core.Entities;
using Core.ViewModels.ContentViewModels;
using Core.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.AutoMapper.Interfaces;

namespace WebApi.AutoMapper.UserAutoMappers
{
    public class UserUpdateMapper : IViewModelMapper<UserUpdateViewModel, User>
    {
        public User Map(UserUpdateViewModel viewModel)
        {
            return new User
            {
                Id = viewModel.Id,
                NickName = viewModel.NickName,
                DateOfBirth = viewModel.DateOfBirth,
                Password = viewModel.Password
            };
        }
    }
}
