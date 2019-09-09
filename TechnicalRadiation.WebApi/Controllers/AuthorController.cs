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
        public IActionResult GetNewsItemsByAuthorId(int id) {
            var newsItems = _authorService.GetNewsItemsByAuthorId(id);
            return Ok(newsItems);
        }

        //http://localhost:5000/api/authors [POST]
        [Route("")]
        [HttpPost]
        [ApiKeyAuthorization] //A version of what I think Arnar wants for authentication (check CustomAttributes folder for implementation)
        public IActionResult CreateAuthor([FromBody] AuthorInputModel body)  { 
            if(!ModelState.IsValid) { return BadRequest("Data was not properly formatted."); }
            var category = _authorService.CreateAuthor(body);
            return CreatedAtRoute("GetAuthorById", new { id = category.Id }, null);
        }
    }
}