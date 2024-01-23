using LuminariasWeb.sln.BusinessInterface;
using LuminariasWeb.sln.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LuminariasWeb.sln.Controllers
{
    [Route("api/Category")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> GetAllCategories()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("GetCategoryById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryViewModel>> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost("AddCategory")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddCategory( CategoryViewModel categoryViewModel)
        {
            try
            {
                await _categoryService.AddCategoryAsync(categoryViewModel);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("UpdateCategory/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryViewModel categoryViewModel)
        {
            var existingCategory = await _categoryService.GetCategoryByIdAsync(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            try
            {
                await _categoryService.UpdateCategoryAsync(categoryViewModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("DeleteCategory/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var existingCategory = await _categoryService.GetCategoryByIdAsync(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            try
            {
                await _categoryService.DeleteCategoryAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }

}
