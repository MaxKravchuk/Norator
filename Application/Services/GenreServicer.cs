using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
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

        public async Task<IEnumerable<Genre>> GetGenreAsync()
        {
            var genres = await _genreRepository.GetAsync();
            return genres;
        }

        public async Task<Genre> GetGenreByIdAsync(int id)
        {
            var genre = await _genreRepository.GetByIdAsync(id);

            if(genre == null)
            {
                throw new Exception();
            }

            return genre;
        }

        public async Task<Genre> GetGenreByNameAsync(string name)
        {
            var genre = await _genreRepository.GetByNameAsync(name);

            if (genre == null)
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
