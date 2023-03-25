using Core.Entities;
using Core.Paginator;
using Core.ViewModels;
using Core.ViewModels.ActorViewModels;
using Core.ViewModels.GenreViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.AutoMapper.Interfaces;

namespace WebApi.AutoMapper.GenreAutoMappers
{
    public class GenrePagedMapper : IViewModelMapper<PagedList<Genre>, PagedReadViewModel<GenreUpdateViewModel>>
    {
        private readonly IEnumerableViewModelMapper<IEnumerable<Genre>,IEnumerable<GenreUpdateViewModel>> _listMapper;
        public GenrePagedMapper(IEnumerableViewModelMapper<IEnumerable<Genre>, IEnumerable<GenreUpdateViewModel>> mapper)
        {
            _listMapper = mapper;
        }
        public PagedReadViewModel<GenreUpdateViewModel> Map(PagedList<Genre> source)
        {
            return new PagedReadViewModel<GenreUpdateViewModel>
            {
                CurrentPage = source.CurrentPage,
                PageSize = source.PageSize,
                TotalCount = source.TotalCount,
                HasPrevious = source.HasPrevious,
                HasNext = source.HasNext,
                TotalPages = source.TotalPages,
                Entities = _listMapper.Map(source.AsEnumerable())
            };
        }
    }
}
