using Core.Entities;
using Core.ViewModels.ActorViewModels;
using Core.ViewModels.ContentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.AutoMapper.Interfaces;

namespace WebApi.AutoMapper.ActorAutoMappers
{
    public class ActorReadMapper : IViewModelMapper<Actor, ActorReadViewModel>
    {
        private readonly IEnumerableViewModelMapper<IEnumerable<Content_Actor>, IEnumerable<ContentActorViewModel>> _contentMapper;

        public ActorReadMapper(IEnumerableViewModelMapper<IEnumerable<Content_Actor>, IEnumerable<ContentActorViewModel>> contentMapper)
        {
            _contentMapper = contentMapper;
        }

        public ActorReadViewModel Map(Actor source)
        {
            var actorReadViewModel = new ActorReadViewModel
            {
                Id = source.Id,
                Name = source.Name,
                DateOfBirth = source.DateOfBirth,
            };

            actorReadViewModel.contentViewModels = _contentMapper.Map(source.Content_Actors);

            return actorReadViewModel;
        }
    }
}
