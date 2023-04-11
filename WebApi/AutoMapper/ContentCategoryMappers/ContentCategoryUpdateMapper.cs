using Core.Entities;
using Core.ViewModels.ContentCategoryViewModels;
using Core.ViewModels.GenreViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.AutoMapper.Interfaces;

namespace WebApi.AutoMapper.ContentCategoryMappers
{
    public class ContentCategoryUpdateMapper : IViewModelMapper<ContentCategoryUpdateViewModel, ContentCategory>
    {
        public ContentCategory Map(ContentCategoryUpdateViewModel model)
        {
            return new ContentCategory()
            {
                Id = model.Id,
                Name = model.Name,
            };
        }
    }
}
