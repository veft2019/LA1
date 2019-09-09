using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Services;

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
        
    }
}