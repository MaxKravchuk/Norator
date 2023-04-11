using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ContentCategoryService : IContentCategoryService
    {
        private readonly IContentCategoryRepository _contentCategoryRepository;
        private readonly ILoggerManager _loggerManager;

        public ContentCategoryService(
            IContentCategoryRepository contentCategoryRepository,
            ILoggerManager loggerManager)
        {
            _contentCategoryRepository = contentCategoryRepository;
            _loggerManager = loggerManager;
        }

        public async Task CreateCategoryAsync(ContentCategory contentCategory)
        {
            await _contentCategoryRepository.InsertAsync(contentCategory);
            try
            {
                await _contentCategoryRepository.SaveChangesAsync();
                _loggerManager.LogInfo($"Category {contentCategory.Name} created successfully");
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Creating error. An error {ex.Message} appears during insertion");
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var catToDelete = await GetCategoryByIdAsync(id);
            _contentCategoryRepository.Delete(catToDelete);
            try
            {
                await _contentCategoryRepository.SaveChangesAsync();
                _loggerManager.LogInfo($"Category with id {id} deleted successfully");
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Deleting error. Error msg - {e.Message}");
            }
        }

        public async Task<IEnumerable<ContentCategory>> GetCategoryAsync()
        {
            var cats = await _contentCategoryRepository.GetAsync();
            _loggerManager.LogInfo($"Goten {cats.Count} categories");
            return cats;
        }

        public async Task<ContentCategory> GetCategoryByIdAsync(int id)
        {
            var cat = await _contentCategoryRepository.GetByIdAsync(id,
                includeProperties: "Contents");

            if (cat == null)
            {
                _loggerManager.LogError($"Category with id {id} does not exist");
                throw new Exception();
            }

            _loggerManager.LogInfo($"Gotten category with id {id}");
            return cat;
        }

        public async Task UpdateCategoryAsync(ContentCategory contentCategory)
        {
            _contentCategoryRepository.Update(contentCategory);
            try
            {
                await _contentCategoryRepository.SaveChangesAsync();
                _loggerManager.LogInfo($"Category with id {contentCategory.Id} updated successfully");
            }
            catch(Exception e)
            {
                _loggerManager.LogError($"Updating error for category {contentCategory.Id}. An error msg - {e.Message}");
            }
        }
    }
}
