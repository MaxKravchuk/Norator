using Core.Entities;
using Core.ViewModels.ContentCategoryViewModels;
using WebApi.AutoMapper.Interfaces;

namespace WebApi.AutoMapper.ContentCategoryMappers
{
    public class ContentCategoryListReadMapper : IEnumerableViewModelMapper<IEnumerable<ContentCategory>, IEnumerable<ContentCategoryReadListViewModel>>
    {
        public IEnumerable<ContentCategoryReadListViewModel> Map(IEnumerable<ContentCategory> models)
        {
            return models.Select(x => new ContentCategoryReadListViewModel()
            {
                Id = x.Id,
                Name = x.Name,
            });
        }
    }
}
