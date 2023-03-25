using Core.Entities;
using Core.ViewModels.GenreViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.AutoMapper.Interfaces;

namespace WebApi.AutoMapper.GenreAutoMappers
{
    public class GenreListReadMapper : IEnumerableViewModelMapper<IEnumerable<Genre>, IEnumerable<GenreUpdateViewModel>>
    {
        public IEnumerable<GenreUpdateViewModel> Map(IEnumerable<Genre> models)
        {
            return models.Select(x => new GenreUpdateViewModel()
            {
                Id = x.Id,
                Name = x.Name,
            });
        }
    }
}
