using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Services;
using TechnicalRadiation.WebApi.CustomAttributes;

namespace TechnicalRadiation.WebApi.Controllers
{
    [Route("/api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        AuthorService _authorService;
        public AuthorController(IMapper mapper) {
            _authorService = new AuthorService(mapper);
        }

        //http://localhost:5000/api/authors [GET]
        [Route("")]
        [HttpGet]
        public IActionResult GetAllAuthors() {
            var authorList = _authorService.GetAllAuthors();
            return Ok(authorList);
        }

        //http://localhost:5000/api/authors/1 [GET]
        [Route("{id:int}", Name = "GetAuthorById")]
        [HttpGet]
        public IActionResult GetAuthorById(int id) {
            var author = _authorService.GetAuthorById(id);
            return Ok(author);
        }

        //http://localhost:5000/api/authors/{authorId}/newsItems [GET]
        [Route("{id:int}/newsItems")]
        [HttpGet]
        public IActionResult GetNewsItemsByAuthorId(int id) {
            var newsItems = _authorService.GetNewsItemsByAuthorId(id);
            return Ok(newsItems);
        }

        /* ========== Authorized routes ===============*/
        //http://localhost:5000/api/authors [POST]
        [Route("")]
        [HttpPost]
        [ApiKeyAuthorization]
        public IActionResult CreateAuthor([FromBody] AuthorInputModel body)  { 
            if(!ModelState.IsValid) { return BadRequest("Data was not properly formatted."); }
            var category = _authorService.CreateAuthor(body);
            return CreatedAtRoute("GetAuthorById", new { id = category.Id }, null);
        }

        //http://localhost:5000/api/authors/1 [PUT]
        [Route("{id:int}")]
        [HttpPut]
        [ApiKeyAuthorization]
        public IActionResult UpdateAuthorById(AuthorInputModel body, int id) {
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }
            _authorService.UpdateAuthorById(body, id);
            return NoContent();
        }

        //http://localhost:5000/api/authors/1 [DELETE]
        [Route("{id:int}")]
        [HttpDelete]
        [ApiKeyAuthorization]
        public IActionResult DeleteAuthorById(int id) {
            _authorService.DeleteAuthorById(id);
            return NoContent();
        }

        //http://localhost:5000/api/authors/{authorId}/newsItems/{newsItemId}
        [Route("{authorId:int}/newsItems/{newsItemId:int}")]
        [HttpPut]
        [ApiKeyAuthorization]
        public IActionResult LinkAuthorToNewsItem(int authorId, int newsItemId) {
            return Ok();
            //Should probably be created at route
        }
    }
}