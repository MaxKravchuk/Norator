using Core.Entities;
using Core.Interfaces.Services;
using Core.ViewModels.ContentCategoryViewModels;
using Microsoft.AspNetCore.Mvc;
using WebApi.AutoMapper.Interfaces;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/contentcategories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IEnumerableViewModelMapper<IEnumerable<ContentCategory>, IEnumerable<ContentCategoryReadListViewModel>> _readMapper;

        public CategoryController(
            ICategoryService categoryService,
            IEnumerableViewModelMapper<IEnumerable<ContentCategory>, IEnumerable<ContentCategoryReadListViewModel>> readMapper)
        {
            _categoryService = categoryService;
            _readMapper = readMapper;
        }

        [HttpGet("getall")]
        public async Task<IEnumerable<ContentCategoryReadListViewModel>> GetAsync()
        {
            var categories = await _categoryService.GetCategoryAsync();
            var viewModels = _readMapper.Map(categories);
            return viewModels;
        }
    }
}
