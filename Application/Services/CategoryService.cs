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
        private readonly ILoggerManager _loggerManager;

        public CategoryService(ICategoryRepository categoryRepository, ILoggerManager loggerManager)
        {
            _categoryRepository = categoryRepository;
            _loggerManager = loggerManager;
        }

        public async Task CreateCategoryAsync(ContentCategory actor)
        {
            await _categoryRepository.InsertAsync(actor);
            try
            {
                await _categoryRepository.SaveChangesAsync();
                _loggerManager.LogInfo("Created category successful");
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Created category error - {ex.Message}");
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var catToDelete = await GetCategoryByIdAsync(id);

            _categoryRepository.Delete(catToDelete);
            try
            {
                await _categoryRepository.SaveChangesAsync();
                _loggerManager.LogInfo($"Deleted category {id} successful");
            }
            catch(Exception ex)
            {
                _loggerManager.LogError($"Deleted category {id} error {ex.Message}");
            }
        }

        public async Task<PagedList<ContentCategory>> GetCategoryAsync(CategoryParameters categoryParameters)
        {
            var filterQuery = GetFilterQuery(categoryParameters.FilterParam);

            var categories = await _categoryRepository.GetAllAsync(
                parameters: categoryParameters,
                filter: filterQuery,
                includeProperties: q => q
                .Include(cc => cc.Contents));

            _loggerManager.LogInfo($"Get list of category {categories.Count}");

            return categories;
        }

        public async Task<ContentCategory> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id, includeProperties: "Contents");

            if(category == null)
            {
                _loggerManager.LogError($"Could not find category {id}");
                throw new NotFoundException();
            }

            _loggerManager.LogInfo($"Find caterory {id}");
            return category;
        }

        public async Task UpdateCategoryAsync(ContentCategory contentCategory)
        {
            _categoryRepository.Update(contentCategory);
            try
            {
                await _categoryRepository.SaveChangesAsync();
                _loggerManager.LogInfo($"Updated {contentCategory.Id}");
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Updated error for actor id {contentCategory.Id} erroe - {ex.Message}");
            }
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
