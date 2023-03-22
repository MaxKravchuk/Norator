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
using Core.ViewModels.ContentViewModels;

namespace WebApi.AutoMapper.ContentAutoMappers
{
    public class ContentPagedMapper : IViewModelMapper<PagedList<Content>, PagedReadViewModel<ContentListReadViewModel>>
    {
        private readonly IEnumerableViewModelMapper<IEnumerable<Content>, IEnumerable<ContentListReadViewModel>> _contentListReadVM;

        public ContentPagedMapper(IEnumerableViewModelMapper<IEnumerable<Content>, IEnumerable<ContentListReadViewModel>> contentListReadVM)
        {
            _contentListReadVM = contentListReadVM;
        }

        public PagedReadViewModel<ContentListReadViewModel> Map(PagedList<Content> source)
        {
            return new PagedReadViewModel<ContentListReadViewModel>
            {
                CurrentPage = source.CurrentPage,
                PageSize = source.PageSize,
                TotalCount = source.TotalCount,
                HasPrevious = source.HasPrevious,
                HasNext = source.HasNext,
                TotalPages = source.TotalPages,
                Entities = _contentListReadVM.Map(source.AsEnumerable())
            };
        }
    }
}
