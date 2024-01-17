using LuminariasWeb.sln.BusinessInterface;
using LuminariasWeb.sln.DataBaseInterface;
using LuminariasWeb.sln.Models;
using LuminariasWeb.sln.ViewModels;

namespace LuminariasWeb.sln.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();
            return categories.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                CategoryName = c.CategoryName
            });
        }

        public async Task<CategoryViewModel> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);
            return category != null ? new CategoryViewModel
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            } : null;
        }

        public async Task AddCategoryAsync(CategoryViewModel categoryViewModel)
        {
            var category = new Category
            {
                CategoryName = categoryViewModel.CategoryName
            };
            await _categoryRepository.AddCategoryAsync(category);
        }

        public async Task UpdateCategoryAsync(CategoryViewModel categoryViewModel)
        {
            var existingCategory = await _categoryRepository.GetCategoryByIdAsync(categoryViewModel.Id);
            if (existingCategory != null)
            {
                existingCategory.CategoryName = categoryViewModel.CategoryName;
                await _categoryRepository.UpdateCategoryAsync(existingCategory);
            }
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            await _categoryRepository.DeleteCategoryAsync(categoryId);
        }
    }
}
