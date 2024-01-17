using LuminariasWeb.sln.ViewModels;

namespace LuminariasWeb.sln.BusinessInterface
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync();
        Task<CategoryViewModel> GetCategoryByIdAsync(int categoryId);
        Task AddCategoryAsync(CategoryViewModel categoryViewModel);
        Task UpdateCategoryAsync(CategoryViewModel categoryViewModel);
        Task DeleteCategoryAsync(int categoryId);
    }
}
