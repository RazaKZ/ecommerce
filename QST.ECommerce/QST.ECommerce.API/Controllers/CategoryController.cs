using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QST.ECommerce.Application;
using QST.ECommerce.Application.Contracts;
using QST.ECommerce.Domain.Catalogue;
using QST.ECommerce.Domain.Enums;

namespace QST.ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICatalogService _categoryService;
        public CategoryController(ICatalogService categoryService) {
            _categoryService = categoryService;
        }

        [HttpPost("AddCategory")]
        public IActionResult AddCategory(Category category)
        {
            _categoryService.ManageCategory(category, DBCommands.Insert);
            // Call the service to manage the category based on the dbCommand
            // For example:
            // int result = _categoryService.ManageCageotry(category, dbCommand);
            // return Ok(result);
            return Ok(); // Placeholder response
        }

        [HttpPost("ModifyCategory")]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryService.ManageCategory(category, DBCommands.Update);
            // Call the service to manage the category based on the dbCommand
            // For example:
            // int result = _categoryService.ManageCageotry(category, dbCommand);
            // return Ok(result);
            return Ok(); // Placeholder response
        }

        [HttpGet("GetCategoryById/{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpGet("GetAllCategories")]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryService.GetAllCategories();
            return Ok(categories);
        }
    }
}
