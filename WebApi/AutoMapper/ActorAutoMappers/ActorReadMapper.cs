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
    public class ActorReadMapper : IViewModelMapper<Actor, ActorViewModel>
    {
        private readonly IViewModelMapper<IEnumerable<Content_Actor>, IEnumerable<ContentViewModel>> _contentMapper;

        public ActorReadMapper(IViewModelMapper<IEnumerable<Content_Actor>, IEnumerable<ContentViewModel>> contentMapper)
        {
            _contentMapper = contentMapper;
        }

        public ActorViewModel Map(Actor source)
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
