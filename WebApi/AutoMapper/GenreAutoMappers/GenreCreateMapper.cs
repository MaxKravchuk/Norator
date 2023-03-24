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
    public class GenreCreateMapper : IViewModelMapper<GenreCreateViewModel, Genre>
    {
        public Genre Map(GenreCreateViewModel model)
        {
            return new Genre()
            {
                Name = model.Name,
            };
        }
    }
}
