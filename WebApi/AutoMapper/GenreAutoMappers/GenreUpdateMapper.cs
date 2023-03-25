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
    public class GenreReadMapper : IViewModelMapper<GenreUpdateViewModel, Genre>
    {
        public Genre Map(GenreUpdateViewModel model)
        {
            return new Genre()
            {
                Id = model.Id,
                Name = model.Name,
            };
        }
    }
}
