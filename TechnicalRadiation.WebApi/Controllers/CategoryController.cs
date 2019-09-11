using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models.Exceptions;
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
            if(categoryList == null) { return StatusCode(500); }
            return Ok(categoryList);
        }
        
        //http://localhost:5000/api/categories/1 [GET]
        [Route("{id:int}", Name = "GetCategoriesById")]
        [HttpGet]
        public IActionResult GetCategoryById(int id) {
            try {
                return Ok(_categoryService.GetCategoryById(id));
            } catch(ContentNotFoundException e) {
                return BadRequest(e.Message);
            }
        }
        
        /* ========== Authorized routes ===============*/
        //http://localhost:5000/api/categories [POST]
        [Route("")]
        [HttpPost]
        [ApiKeyAuthorization] //A version of what I think Arnar wants for authentication (check CustomAttributes folder for implementation)
        public IActionResult CreateCategory([FromBody] CategoryInputModel body)  { 
            if(!ModelState.IsValid) { return BadRequest("Data was not properly formatted."); }
            var category = _categoryService.CreateCategory(body);
            return CreatedAtRoute("GetCategoriesById", new { id = category.Id }, null);
        }

        //http://localhost:5000/api/categories/1 [PUT]
        [Route("{id:int}")]
        [HttpPut]
        [ApiKeyAuthorization]
        public IActionResult UpdateCategoryById([FromBody] CategoryInputModel body, int id) {
            if(!ModelState.IsValid) { return BadRequest("Data was not properly formatted."); }
            _categoryService.UpdateCategoryById(body, id);
            return NoContent();
        }

        //http://localhost:5000/api/categories/1/newsItems/1 [POST]
        [Route("{categoryId:int}/newsItems/{newsItemId:int}")]
        [HttpPost]
        [ApiKeyAuthorization]
        public IActionResult ConnectNewsItemToCategory(int categoryId, int newsItemId) {
            try {
                _categoryService.ConnectNewsItemToCategory(categoryId, newsItemId);
                return NoContent();
            } catch(ContentNotFoundException e) {
                return BadRequest(e.Message);
            }
        }

        //http://localhost:5000/api/categories/1 [DELETE]
        [Route("{id:int}")]
        [HttpDelete]
        [ApiKeyAuthorization]
        public IActionResult DeleteCategoriesById(int id) {
            _categoryService.DeleteCategoriesById(id);
            return NoContent();
        }
    }
}