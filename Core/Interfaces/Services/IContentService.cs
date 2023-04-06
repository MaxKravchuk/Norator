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
    public interface IContenService
    {
        Task<Content> GetContentByIdAsync(int id);
        //Task<IEnumerable<Content>> GetContentByUserIdAsync(int id);
        Task<PagedList<Content>> GetContentsAsync(ContentParameters contentParameters);
        Task CreateContentAsync(Content content, IEnumerable<int> actorsId, IEnumerable<int> genresId);
        Task UpdateContentAsync(Content content, IEnumerable<int> actorsId, IEnumerable<int> genresId);
        Task DeleteContentAsync(int id);
        Task<IEnumerable<Content>> GetTop20ContentAsync();

    }
}
