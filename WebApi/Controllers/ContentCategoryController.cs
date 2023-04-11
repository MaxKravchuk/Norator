using Core.Entities;
using Core.Interfaces.Services;
using Core.ViewModels.ContentCategoryViewModels;
using Microsoft.AspNetCore.Mvc;
using WebApi.AutoMapper.Interfaces;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/contentcategories")]
    public class ContentCategoryController : ControllerBase
    {
        private readonly IContentCategoryService _contentCategoryService;
        private readonly IViewModelMapper<ContentCategoryCreateViewModel, ContentCategory> _createMapper;
        private readonly IEnumerableViewModelMapper<IEnumerable<ContentCategory>, IEnumerable<ContentCategoryReadListViewModel>> _readMapper;
        private readonly IViewModelMapper<ContentCategoryUpdateViewModel, ContentCategory> _updateMapper;

        public ContentCategoryController(
            IContentCategoryService contentCategoryService,
            IViewModelMapper<ContentCategoryCreateViewModel, ContentCategory> create_Mapper,
            IEnumerableViewModelMapper<IEnumerable<ContentCategory>, IEnumerable<ContentCategoryReadListViewModel>> readMapper,
            IViewModelMapper<ContentCategoryUpdateViewModel, ContentCategory> updateMapper)
        {
            _contentCategoryService = contentCategoryService;
            _createMapper = create_Mapper;
            _readMapper = readMapper;
            _updateMapper = updateMapper;
        }

        [HttpGet("getall")]
        public async Task<IEnumerable<ContentCategoryReadListViewModel>> GetAsync()
        {
            var genres = await _contentCategoryService.GetCategoryAsync();
            var viewModels = _readMapper.Map(genres);
            return viewModels;
        }

        [HttpPost]
        public async Task CreateGenreAsync([FromBody] ContentCategoryCreateViewModel contentCategoryCreateViewModel)
        {
            var cc = _createMapper.Map(contentCategoryCreateViewModel);
            await _contentCategoryService.CreateCategoryAsync(cc);
        }

        [HttpPut()]
        public async Task UpdateAsync([FromBody] ContentCategoryUpdateViewModel contentCategoryUpdateViewModel)
        {
            var newCC = _updateMapper.Map(contentCategoryUpdateViewModel);
            await _contentCategoryService.UpdateCategoryAsync(newCC);
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task DeleteAsync([FromRoute] int id)
        {
            await _contentCategoryService.DeleteCategoryAsync(id);
        }
    }
}
