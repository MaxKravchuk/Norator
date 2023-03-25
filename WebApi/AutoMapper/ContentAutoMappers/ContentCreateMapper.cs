using Core.Entities;
using Core.Enums;
using Core.ViewModels.ContentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.AutoMapper.Interfaces;

namespace WebApi.AutoMapper.ContentAutoMappers
{
    public class ContentCreateMapper : IViewModelMapper<ContentCreateViewModel, Content>
    {
        public Content Map(ContentCreateViewModel viewModel)
        {
            return new Content
            {
                Name = viewModel.Name,
                ReleaseDate = viewModel.ReleaseDate,
                ContentCategoryId = viewModel.ContentCategoryId,
            };
        }
    }
}
