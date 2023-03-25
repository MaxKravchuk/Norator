using Core.Entities;
using Core.ViewModels.ActorViewModels;
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
    public class UserLogInapper : IViewModelMapper<User, UserReadListViewModel>
    {
        public UserReadListViewModel Map(User source)
        {
            var userReadViewModel = new UserReadListViewModel
            {
                Id = source.Id,
                NickName = source.NickName,
            };
            return userReadViewModel;
        }
    }
}
