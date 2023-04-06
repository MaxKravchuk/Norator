using Core.Entities;
using Core.Paginator.Parameters;
using Core.Paginator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<ContentCategory> GetCategoryByIdAsync(int id);
        Task<PagedList<ContentCategory>> GetCategoryAsync(CategoryParameters categoryParameters);
        Task CreateCategoryAsync(ContentCategory actor);
        Task UpdateCategoryAsync(ContentCategory actor);
        Task DeleteCategoryAsync(int id);
    }
}
