using Core.Entities;
using Core.ViewModels.ActorViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.AutoMapper.Interfaces;

namespace WebApi.AutoMapper.ActorAutoMappers
{
    public interface ActorListToListMapper : IEnumerableViewModelMapper<IEnumerable<Actor>, IEnumerable<ActorViewModel>>
    {
        public IEnumerable<ActorViewModel> Map(IEnumerable<Actor> source)
        {
            var dest = source.Select(GetAnimalViewModel).ToList();
            return dest;
        }

        private ActorViewModel GetAnimalViewModel(Actor actor)
        {
            var actorViewModel = new ActorViewModel()
            {
                Id = actor.Id,
                Name = actor.Name,
                DateOfBirth = actor.DateOfBirth,
            };

            return actorViewModel;
        }
    }
}
