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
    public class ActorListReadMapper : IEnumerableViewModelMapper<IEnumerable<Actor>,IEnumerable<ActorListReadViewModel>>
    {
        public IEnumerable<ActorListReadViewModel> Map(IEnumerable<Actor> source)
        {
            var actorsVM = source.Select(GetVM).ToList();
            return actorsVM;

        }

        private ActorListReadViewModel GetVM(Actor actor)
        {
            return new ActorListReadViewModel
            {
                Id = actor.Id,
                Name = actor.Name,
                DateOfBirth = actor.DateOfBirth,
            };
        }
    }
}
