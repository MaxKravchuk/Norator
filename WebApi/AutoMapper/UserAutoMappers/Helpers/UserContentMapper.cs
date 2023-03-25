using Core.Entities;
using Core.ViewModels.ContentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.AutoMapper.Interfaces;

namespace WebApi.AutoMapper.UserAutoMappers.Helpers
{
    public class UserContentMapper : IEnumerableViewModelMapper<IEnumerable<User_Content>, IEnumerable<ContentListReadViewModel>>
    {
        public IEnumerable<ContentListReadViewModel> Map(IEnumerable<User_Content> source)
        {
            var userContentVM = source.Select(x => new ContentListReadViewModel
            {
                Id = x.ContentId,
                Name = x.Content.Name,
                ContentCategory = x.Content.ContentCategory.Name,
            });
            return userContentVM;
        }
    }
}
