using Core.Entities;
using Core.ViewModels.ContentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.AutoMapper.Interfaces;

namespace WebApi.AutoMapper.ActorAutoMappers
{
    public class ActorContentMapper : IEnumerableViewModelMapper<IEnumerable<Content_Actor>, IEnumerable<ContentActorViewModel>>
    {
        public IEnumerable<ContentActorViewModel> Map(IEnumerable<Content_Actor> source)
        {
            var actorContentVM = source.Select(x => new ContentActorViewModel
            {
                Id = x.ContentId,
                Name = x.Content.Name,
            });

            return actorContentVM;
        }
    }
}
