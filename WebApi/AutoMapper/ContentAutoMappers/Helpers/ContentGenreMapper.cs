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
    public class ContentGenreMapper : IEnumerableViewModelMapper<IEnumerable<Content_Genre>, IEnumerable<ContentPropsViewModel>>
    {
        public IEnumerable<ContentPropsViewModel> Map(IEnumerable<Content_Genre> source)
        {
            var genreContentVM = source.Select(x => new ContentPropsViewModel
            {
                Id = x.GenreId,
                Name = x.Genre.Name
            });

            return genreContentVM;
        }
    }
}
