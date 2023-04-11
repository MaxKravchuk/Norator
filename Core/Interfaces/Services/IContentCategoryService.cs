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
    public interface IContentCategoryService
    {
        Task<ContentCategory> GetCategoryByIdAsync(int id);
        Task<IEnumerable<ContentCategory>> GetCategoryAsync();
        Task CreateCategoryAsync(ContentCategory contentCategory);
        Task UpdateCategoryAsync(ContentCategory contentCategory);
        Task DeleteCategoryAsync(int id);

    }
}
