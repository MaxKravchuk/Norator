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
    public class ActorCreateMapper : IViewModelMapper<ActorCreateViewModel, Actor>
    {
        public Actor Map(ActorCreateViewModel model)
        {
            return new Actor()
            {
                Name = model.Name,
                DateOfBirth = model.DateOfBirth,
            };
        }
    }
}
