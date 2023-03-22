using Core.Entities;
using Core.Enums;
using Core.ViewModels.ActorViewModels;
using Core.ViewModels.ContentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.AutoMapper.Interfaces;

namespace WebApi.AutoMapper.ContentAutoMappers
{
    public class ContentListReadMapper : IEnumerableViewModelMapper<IEnumerable<Content>, IEnumerable<ContentListReadViewModel>>
    {
        public IEnumerable<ContentListReadViewModel> Map(IEnumerable<Content> source)
        {
            var contentsVM = source.Select(GetVM).ToList();
            return contentsVM;

        }

        private ContentListReadViewModel GetVM(Content content)
        {
            return new ContentListReadViewModel
            {
                Id = content.Id,
                Name = content.Name,
                ReleaseDate = content.ReleaseDate,
                ContentCategory = content.ContentCategory.Name
            };
        }
    }
}
