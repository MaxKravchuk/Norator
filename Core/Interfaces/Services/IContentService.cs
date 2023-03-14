using Core.Entities;
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
        Task<Content> GetContentByNameAsync(string name);
        Task<IEnumerable<Content>> GetContentsAsync();
        Task CreateContentAsync(Content content);
        Task UpdateContentAsync(Content content);
        Task DeleteContentAsync(int id);

    }
}
