using Core.Entities;
using Core.Interfaces.Services;
using Core.Paginator;
using Core.Paginator.Parameters;
using Core.ViewModels;
using Core.ViewModels.GenreViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.AutoMapper.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/genre")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        private readonly IViewModelMapper<GenreCreateViewModel, Genre> _genreCreateMapper;
        private readonly IViewModelMapper<GenreUpdateViewModel, Genre> _genreUpdateMapper;
        private readonly IViewModelMapper<PagedList<Genre>, PagedReadViewModel<GenreUpdateViewModel>> _pagedListMapper;

        public GenreController(
            IGenreService genreService,
            IViewModelMapper<GenreCreateViewModel, Genre> genreCreateVM,
            IViewModelMapper<GenreUpdateViewModel, Genre> genreRUMapper,
            IViewModelMapper<PagedList<Genre>, PagedReadViewModel<GenreUpdateViewModel>> pagedListMapper)
        {
            _genreService = genreService;
            _genreCreateMapper = genreCreateVM;
            _genreUpdateMapper = genreRUMapper;
            _pagedListMapper = pagedListMapper;
        }

        [HttpGet("getall")]
        public async Task<PagedReadViewModel<GenreUpdateViewModel>> GetAsync([FromQuery] GenreParameters genreParameters)
        {
            var genres = await _genreService.GetGenreAsync(genreParameters);
            var viewModels = _pagedListMapper.Map(genres);
            return viewModels;
        }

        [HttpPost]
        public async Task CreateGenreAsync([FromBody] GenreCreateViewModel genreCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var genre = _genreCreateMapper.Map(genreCreateViewModel);
                await _genreService.CreateGenreAsync(genre);
            }
        }

        [HttpPut()]
        public async Task UpdateAsync([FromBody] GenreUpdateViewModel genreUpdateViewModel)
        {
            if(ModelState.IsValid)
            {
                var newGenre = _genreUpdateMapper.Map(genreUpdateViewModel);
                await _genreService.UpdateGenreAsync(newGenre);
            }
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task DeleteAsync([FromRoute] int id)
        {
            await _genreService.DeleteGenreAsync(id);
        }
    }
}
