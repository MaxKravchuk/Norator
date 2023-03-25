using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Paginator;
using Core.Paginator.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task CreateGenreAsync(Genre genre)
        {
            await _genreRepository.InsertAsync(genre);
            await _genreRepository.SaveChangesAsync();
        }

        public async Task DeleteGenreAsync(int id)
        {
            var genretoDelete = await GetGenreByIdAsync(id);

            _genreRepository.Delete(genretoDelete);
            await _genreRepository.SaveChangesAsync();
        }

        public async Task<PagedList<Genre>> GetGenreAsync(GenreParameters genreParameters)
        {
            var genres = await _genreRepository.GetAllAsync(genreParameters);
            return genres;
        }

        public async Task<Genre> GetGenreByIdAsync(int id)
        {
            var genre = await _genreRepository.GetByIdAsync(id,
                includeProperties: "Content_Genres.Content");

            if(genre == null)
            {
                throw new Exception();
            }

            return genre;
        }

        public async Task UpdateGenreAsync(Genre genre)
        {
            _genreRepository.Update(genre);
            await _genreRepository.SaveChangesAsync();
        }
    }
}
