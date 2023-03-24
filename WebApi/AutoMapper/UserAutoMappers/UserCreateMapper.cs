using Core.Entities;
using Core.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.AutoMapper.Interfaces;

namespace WebApi.AutoMapper.UserAutoMappers
{
    public class UserCreateMapper : IViewModelMapper<UserCreateViewModel, User>
    {
        public User Map(UserCreateViewModel model)
        {
            return new User()
            {
                NickName = model.NickName,
                DateOfBirth = model.DateOfBirth,
                Password = model.Password,
                UserType = Core.Enums.UserType.Client,
            };
        }
    }
}
