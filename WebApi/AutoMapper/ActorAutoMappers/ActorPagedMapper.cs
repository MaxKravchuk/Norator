using Core.Entities;
using Core.Paginator;
using Core.ViewModels;
using Core.ViewModels.ActorViewModels;
using Core.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.AutoMapper.Interfaces;

namespace WebApi.AutoMapper.ActorAutoMappers
{
    public class ActorPagedMapper : IViewModelMapper<PagedList<Actor>, PagedReadViewModel<ActorListReadViewModel>>
    {
        private readonly IEnumerableViewModelMapper<IEnumerable<Actor>, IEnumerable<ActorListReadViewModel>> _actorListReadVM;

        public ActorPagedMapper(IEnumerableViewModelMapper<IEnumerable<Actor>, IEnumerable<ActorListReadViewModel>> actorListReadVM)
        {
            _actorListReadVM = actorListReadVM;
        }

        public PagedReadViewModel<ActorListReadViewModel> Map(PagedList<Actor> source)
        {
            return new PagedReadViewModel<ActorListReadViewModel>
            {
                CurrentPage = source.CurrentPage,
                PageSize = source.PageSize,
                TotalCount = source.TotalCount,
                HasPrevious = source.HasPrevious,
                HasNext = source.HasNext,
                TotalPages = source.TotalPages,
                Entities = _actorListReadVM.Map(source.AsEnumerable())
            };
        }
    }
}
