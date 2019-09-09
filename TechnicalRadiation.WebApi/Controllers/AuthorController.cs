using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Services;

namespace TechnicalRadiation.WebApi.Controllers
{
    [Route("/api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        AuthorService _authorService = new AuthorService();

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
    }
}