using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Services;
using TechnicalRadiation.WebApi.CustomAttributes;

namespace TechnicalRadiation.WebApi.Controllers
{
    [Route("/api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        CategoryService _categoryService = new CategoryService();

        //http://localhost:5000/api/categories [GET]
        [Route("")]
        [HttpGet]
        public IActionResult GetAllCategories() {
            var categoryList = _categoryService.GetAllCategories();
            return Ok(categoryList);
        }
    }
}