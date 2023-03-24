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
    public class UserListReadMapper : IEnumerableViewModelMapper<IEnumerable<User>, IEnumerable<UserReadListViewModel>>
    {
        public IEnumerable<UserReadListViewModel> Map(IEnumerable<User> source)
        {
            var usersVM = source.Select(GetVM).ToList();
            return usersVM;

        }

        private UserReadListViewModel GetVM(User content)
        {
            return new UserReadListViewModel
            {
                Id = content.Id,
                NickName = content.NickName,
            };
        }
    }
}
