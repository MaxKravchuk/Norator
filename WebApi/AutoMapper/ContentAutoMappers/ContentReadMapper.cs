using Core.Entities;
using Core.ViewModels.ActorViewModels;
using Core.ViewModels.ContentViewModels;
using Core.ViewModels.GenreViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using WebApi.AutoMapper.Interfaces;

namespace WebApi.AutoMapper.ContentAutoMappers
{
    public class ContentReadMapper : IViewModelMapper<Content, ContentReadViewModel>
    {
        private readonly IEnumerableViewModelMapper<IEnumerable<Content_Actor>, IEnumerable<ContentPropsViewModel>> _actorListMapper;
        private readonly IEnumerableViewModelMapper<IEnumerable<Content_Genre>, IEnumerable<ContentPropsViewModel>> _genreListMapper;

        public ContentReadMapper(
            IEnumerableViewModelMapper<IEnumerable<Content_Actor>, IEnumerable<ContentPropsViewModel>> actorListMapper,
            IEnumerableViewModelMapper<IEnumerable<Content_Genre>, IEnumerable<ContentPropsViewModel>> genreListMapper)
        {
            _actorListMapper = actorListMapper;
            _genreListMapper = genreListMapper;
        }

        public ContentReadViewModel Map(Content source)
        {
            var contentReadViewModel = new ContentReadViewModel
            {
                Id = source.Id,
                Name = source.Name,
                ReleaseDate = source.ReleaseDate,
                ContentCategory = source.ContentCategory.Name,
                NumberOfSubscribers = source.NumberOfSubscribers
            };
            contentReadViewModel.actorsViewModels = _actorListMapper.Map(source.Content_Actors);
            contentReadViewModel.genreViewModels = _genreListMapper.Map(source.Content_Genres);
            return contentReadViewModel;
        }
    }
}
