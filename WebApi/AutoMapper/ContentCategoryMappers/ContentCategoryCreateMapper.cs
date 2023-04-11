using Core.Entities;
using Core.ViewModels.ContentCategoryViewModels;
using WebApi.AutoMapper.Interfaces;

namespace WebApi.AutoMapper.ContentCategoryMappers
{
    public class ContentCategoryCreateMapper : IViewModelMapper<ContentCategoryCreateViewModel, ContentCategory>
    {
        public ContentCategory Map(ContentCategoryCreateViewModel model)
        {
            return new ContentCategory()
            {
                Name = model.Name,
            };
        }
    }
}
