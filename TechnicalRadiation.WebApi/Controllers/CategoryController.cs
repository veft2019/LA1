using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Services;
using TechnicalRadiation.WebApi.CustomAttributes;

namespace TechnicalRadiation.WebApi.Controllers
{
    [Route("/api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        CategoryService _categoryService;
        public CategoryController(IMapper mapper) {
            _categoryService = new CategoryService(mapper);
        }

        //http://localhost:5000/api/categories [GET]
        [Route("")]
        [HttpGet]
        public IActionResult GetAllCategories() {
            var categoryList = _categoryService.GetAllCategories();
            return Ok(categoryList);
        }
        
        //http://localhost:5000/api/categories/1 [GET]
        [Route("{id:int}", Name = "GetCategoriesById")]
        [HttpGet]
        public IActionResult GetCategoryById(int id) {
            var category = _categoryService.GetCategoryById(id);
            return Ok(category);
        }

        //http://localhost:5000/api/categories [POST]
        [Route("")]
        [HttpPost]
        [ApiKeyAuthorization] //A version of what I think Arnar wants for authentication (check CustomAttributes folder for implementation)
        public IActionResult CreateNewsItem([FromBody] CategoryInputModel body)  { 
            if(!ModelState.IsValid) { return BadRequest("Data was not properly formatted."); }
            var category = _categoryService.CreateCategory(body);
            return CreatedAtRoute("GetNewsItemsById", new { id = category.Id }, null);
        }
    }
}