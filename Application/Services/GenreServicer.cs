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
        private readonly ILoggerManager _loggerManager;

        public GenreService(IGenreRepository genreRepository, ILoggerManager loggerManager)
        {
            _genreRepository = genreRepository;
            _loggerManager = loggerManager;
        }

        public async Task CreateGenreAsync(Genre genre)
        {
            await _genreRepository.InsertAsync(genre);
            try
            {
                await _genreRepository.SaveChangesAsync();
                _loggerManager.LogInfo($"Genre {genre.Name} created successfully");
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Creating error. An error {e.Message} appears during insertion");
            }
        }

        public async Task DeleteGenreAsync(int id)
        {
            var genretoDelete = await GetGenreByIdAsync(id);

            _genreRepository.Delete(genretoDelete);
            try
            {
                await _genreRepository.SaveChangesAsync();
                _loggerManager.LogInfo($"Genre with id {id} deleted successfully");
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Deleting error. Error msg - {e.Message}");
            }
        }

        public async Task<PagedList<Genre>> GetGenreAsync(GenreParameters genreParameters)
        {
            var genres = await _genreRepository.GetAllAsync(genreParameters);
            _loggerManager.LogInfo($"Getted {genres.Count} genres");
            return genres;
        }

        public async Task<Genre> GetGenreByIdAsync(int id)
        {
            var genre = await _genreRepository.GetByIdAsync(id,
                includeProperties: "Content_Genres.Content");

            if(genre == null)
            {
                _loggerManager.LogError($"Genre with id {id} does not exist");
                throw new Exception();
            }

            _loggerManager.LogInfo($"Getted genre with id {id}");
            return genre;
        }

        public async Task UpdateGenreAsync(Genre genre)
        {
            _genreRepository.Update(genre);
            try
            {
                await _genreRepository.SaveChangesAsync();
                _loggerManager.LogInfo($"Genre with id {genre.Id} updated successfully");
            }
            catch(Exception e)
            {
                _loggerManager.LogError($"Updating error for genre {genre.Id}. An error msg - {e.Message}");
            }
        }
    }
}
