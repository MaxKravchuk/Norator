using Core.Entities;
using Core.Paginator;
using Core.ViewModels.ActorViewModels;
using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.AutoMapper.Interfaces;
using Core.ViewModels.UserViewModels;

namespace WebApi.AutoMapper.UserAutoMappers
{
    public class UserPagedMapper : IViewModelMapper<PagedList<User>, PagedReadViewModel<UserReadListViewModel>>
    {
        private readonly IEnumerableViewModelMapper<IEnumerable<User>, IEnumerable<UserReadListViewModel>> _userReadListVM;
        public UserPagedMapper(IEnumerableViewModelMapper<IEnumerable<User>, IEnumerable<UserReadListViewModel>> userReadListVM)
        {
            _userReadListVM = userReadListVM;
        }
        public PagedReadViewModel<UserReadListViewModel> Map(PagedList<User> source)
        {
            return new PagedReadViewModel<UserReadListViewModel>
            {
                CurrentPage = source.CurrentPage,
                PageSize = source.PageSize,
                TotalCount = source.TotalCount,
                HasPrevious = source.HasPrevious,
                HasNext = source.HasNext,
                TotalPages = source.TotalPages,
                Entities = _userReadListVM.Map(source.AsEnumerable())
            };
        }
    }
}
