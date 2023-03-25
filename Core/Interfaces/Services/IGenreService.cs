using Core.Entities;
using Core.Paginator;
using Core.Paginator.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IGenreService
    {
        Task<Genre> GetGenreByIdAsync(int id);
        Task<PagedList<Genre>> GetGenreAsync(GenreParameters genreParameters);
        Task CreateGenreAsync(Genre genre);
        Task UpdateGenreAsync(Genre genre);
        Task DeleteGenreAsync(int id);

    }
}
