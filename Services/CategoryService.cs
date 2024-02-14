using AutoMapper;
using LuminariasWeb.sln.Models;
using LuminariasWeb.sln.DataBaseInterface;
using LuminariasWeb.sln.BusinessInterface;
using LuminariasWeb.sln.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuminariasWeb.sln.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
        }

        public async Task<CategoryViewModel> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);
            return _mapper.Map<CategoryViewModel>(category);
        }

        public async Task AddCategoryAsync(CategoryViewModel categoryViewModel)
        {
            var category = _mapper.Map<Category>(categoryViewModel);
            await _categoryRepository.AddCategoryAsync(category);
        }

        public async Task UpdateCategoryAsync(CategoryViewModel categoryViewModel)
        {
            var existingCategory = await _categoryRepository.GetCategoryByIdAsync(categoryViewModel.Id);
            if (existingCategory != null)
            {
                _mapper.Map(categoryViewModel, existingCategory);
                await _categoryRepository.UpdateCategoryAsync(existingCategory);
            }
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            await _categoryRepository.DeleteCategoryAsync(categoryId);
        }
    }
}
