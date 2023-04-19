using Core.Entities;
using Core.Interfaces.Services;
using Core.Paginator;
using Core.Paginator.Parameters;
using Core.ViewModels;
using Core.ViewModels.ActorViewModels;
using Core.ViewModels.ContentViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.AutoMapper.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/content")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IContenService _contenService;
        private readonly IViewModelMapper<ContentCreateViewModel, Content> _createMapper;
        private readonly IViewModelMapper<ContentUpdateViewModel, Content> _updateMapper;
        private readonly IViewModelMapper<Content, ContentReadViewModel> _readMapper;
        private readonly IEnumerableViewModelMapper<IEnumerable<Content>, IEnumerable<ContentListReadViewModel>> _readListMapper;
        private readonly IViewModelMapper<PagedList<Content>, PagedReadViewModel<ContentListReadViewModel>> _pagedListMapper;

        public ContentController(
            IContenService contenService,
            IViewModelMapper<ContentCreateViewModel, Content> createMapper,
            IViewModelMapper<ContentUpdateViewModel, Content> updateMapper,
            IViewModelMapper<Content, ContentReadViewModel> readMapper,
            IViewModelMapper<PagedList<Content>, PagedReadViewModel<ContentListReadViewModel>> pagedListMapper,
            IEnumerableViewModelMapper<IEnumerable<Content>, IEnumerable<ContentListReadViewModel>> readListMapper
            )
        {
            _contenService = contenService;
            _createMapper = createMapper;
            _updateMapper = updateMapper;
            _readMapper = readMapper;
            _pagedListMapper = pagedListMapper;
            _readListMapper = readListMapper;
        }

        [HttpGet("getall")]
        public async Task<PagedReadViewModel<ContentListReadViewModel>> GetAsync([FromQuery] ContentParameters contentParameters)
        {
            var contents = await _contenService.GetContentsAsync(contentParameters);
            var viewModels = _pagedListMapper.Map(contents);
            return viewModels;
        }

        [HttpGet("{id:int:min(1)}")]
        public async Task<ContentReadViewModel> GetAsync([FromRoute] int id)
        {
            var content = await _contenService.GetContentByIdAsync(id);
            var viewModel = _readMapper.Map(content);
            return viewModel;
        }

        [HttpPost]
        public async Task CreateContent([FromBody] ContentCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var content = _createMapper.Map(viewModel);
                await _contenService.CreateContentAsync(content, viewModel.Actors, viewModel.Genres);
            }
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task DeleteAsync([FromRoute] int id)
        {
            await _contenService.DeleteContentAsync(id);
        }

        [HttpPut]
        public async Task UpdateAsync([FromBody] ContentUpdateViewModel newContent)
        {
            if (ModelState.IsValid)
            {
                var updatedContent = _updateMapper.Map(newContent);
                await _contenService.UpdateContentAsync(updatedContent, newContent.actorsId, newContent.genresId);
            }
        }

        [HttpGet("gettop20")]
        public async Task<IEnumerable<ContentListReadViewModel>> GetTop20Async()
        {
            var contents = await _contenService.GetTop20ContentAsync();
            var viewModels = _readListMapper.Map(contents);
            return viewModels;
        }

        [HttpGet("gettop20/{categoryId:int:min(1)}")]
        public async Task<IEnumerable<ContentListReadViewModel>> GetTop20Async([FromRoute] int categoryId)
        {
            var contents = await _contenService.GetTop20ContentByCategoryAsync(categoryId);
            var viewModels = _readListMapper.Map(contents);
            return viewModels;
        }
    }
}
