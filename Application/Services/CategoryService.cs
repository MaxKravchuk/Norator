using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Paginator;
using Core.Paginator.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task CreateCategoryAsync(ContentCategory actor)
        {
            await _categoryRepository.InsertAsync(actor);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var catToDelete = await GetCategoryByIdAsync(id);

            _categoryRepository.Delete(catToDelete);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task<PagedList<ContentCategory>> GetCategoryAsync(CategoryParameters categoryParameters)
        {
            var filterQuery = GetFilterQuery(categoryParameters.FilterParam);

            var categories = await _categoryRepository.GetAllAsync(
                parameters: categoryParameters,
                filter: filterQuery,
                includeProperties: q => q
                .Include(cc => cc.Contents));

            return categories;
        }

        public async Task<ContentCategory> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id, includeProperties: "Contents");

            if(category == null)
            {
                throw new NotFoundException();
            }

            return category;
        }

        public async Task UpdateCategoryAsync(ContentCategory actor)
        {
            _categoryRepository.Update(actor);
            await _categoryRepository.SaveChangesAsync();
        }

        private static Expression<Func<ContentCategory, bool>>? GetFilterQuery(string? filterParam)
        {
            Expression<Func<ContentCategory, bool>>? filterQuery = null;

            if (filterParam is not null)
            {
                string formatedFilter = filterParam.Trim().ToLower();

                filterQuery = u => u.Name!.ToLower().Contains(formatedFilter);
            }

            return filterQuery;
        }
    }
}
