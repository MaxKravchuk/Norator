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
    public class ActorViewModelMapper : IViewModelMapperUpdater<ActorViewModel, Actor>
    {
        public Actor Map(ActorViewModel source)
        {
            var actor = new Actor
            {
                Id = source.Id,
                Name = source.Name,
                DateOfBirth = source.DateOfBirth,
            };

            return actor;
        }

        public void Map(ActorViewModel source, Actor dest)
        {
            dest.Id = source.Id;
            dest.Name = source.Name;
            dest.DateOfBirth = source.DateOfBirth;
        }
    }
}
