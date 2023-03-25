using Core.Entities;
using Core.ViewModels.ContentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.AutoMapper.Interfaces;

namespace WebApi.AutoMapper.ContentAutoMappers.Helpers
{
    public class ContentActorMapper : IEnumerableViewModelMapper<IEnumerable<Content_Actor>, IEnumerable<ContentPropsViewModel>>
    {
        public IEnumerable<ContentPropsViewModel> Map(IEnumerable<Content_Actor> source)
        {
            var actorContentVM = source.Select(x => new ContentPropsViewModel
            {
                Id = x.ActorId,
                Name = x.Actor.Name
            });

            return actorContentVM;
        }
    }
}
