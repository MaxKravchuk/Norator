using Core.Entities;
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
        Task<IEnumerable<Genre>> GetGenreByNameAsync(string name);
        Task<IEnumerable<Genre>> GetGenreAsync();
        Task CreateGenreAsync(Genre genre);
        Task UpdateGenreAsync(Genre genre);
        Task DeleteGenreAsync(int id);

    }
}
