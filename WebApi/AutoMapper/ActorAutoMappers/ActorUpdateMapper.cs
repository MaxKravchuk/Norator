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
    public class ActorUpdateMapper : IViewModelMapper<ActorUpdateViewModel, Actor>
    {
        public Actor Map(ActorUpdateViewModel model)
        {
            return new Actor()
            {
                Id = model.Id,
                Name = model.Name,
                DateOfBirth = model.DateOfBirth,
            };
        }
    }
}
