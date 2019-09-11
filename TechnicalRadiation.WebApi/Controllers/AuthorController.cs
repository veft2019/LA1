using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models.Exceptions;
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
            if(authorList == null) { return StatusCode(500); }
            return Ok(authorList);
        }

        //http://localhost:5000/api/authors/1 [GET]
        [Route("{id:int}", Name = "GetAuthorById")]
        [HttpGet]
        public IActionResult GetAuthorById(int id) {
            try {
                return Ok(_authorService.GetAuthorById(id));
            } catch(ContentNotFoundException e) {
                return NotFound(e.Message);
            }
        }

        //http://localhost:5000/api/authors/{authorId}/newsItems [GET]
        [Route("{id:int}/newsItems")]
        [HttpGet]
        public IActionResult GetNewsItemsByAuthorId(int id) {
            try {
                return Ok(_authorService.GetNewsItemsByAuthorId(id));
            } catch(ContentNotFoundException e) {
                return NotFound(e.Message);
            }
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

        //http://localhost:5000/api/authors/{authorId}/newsItems/{newsItemId} [POST]
        [Route("{authorId:int}/newsItems/{newsItemId:int}")]
        [HttpPost]
        [ApiKeyAuthorization]
        public IActionResult ConnectNewsItemToAuthor(int authorId, int newsItemId) {
            try {
                _authorService.ConnectNewsItemToAuthor(authorId, newsItemId);
            
                //Just a standard 201 becuase there is no path created for this connection
                return StatusCode(201);
            } catch(ConnectionExistsException e) {
                return BadRequest(e.Message);
            }
            
        }
    }
}