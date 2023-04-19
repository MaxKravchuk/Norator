using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Paginator;
using Core.Paginator.Parameters;
using Core.ViewModels.ContentCategoryViewModels;
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

        public async Task<IEnumerable<ContentCategory>> GetCategoryAsync()
        {
            var categories = await _categoryRepository.GetAsync();
            _loggerManager.LogInfo($"Get list of category {categories.Count}");
            return categories;
        }
    }
}
