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
    public class UserReadMapper : IViewModelMapper<User, UserReadViewModel>
    {
        private readonly IEnumerableViewModelMapper<IEnumerable<User_Content>, IEnumerable<ContentListReadViewModel>> _contentMapper;

        public UserReadMapper(
            IEnumerableViewModelMapper<IEnumerable<User_Content>, IEnumerable<ContentListReadViewModel>> contentMapper)
        {
            _contentMapper = contentMapper;
        }

        public UserReadViewModel Map(User source)
        {
            var userReadViewModel = new UserReadViewModel
            {
                Id = source.Id,
                NickName = source.NickName,
                DateOfBirth = source.DateOfBirth,
            };
            userReadViewModel.contentViewModels = _contentMapper.Map(source.User_Contents);
            return userReadViewModel;
        }
    }
}
