using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Services;
using TechnicalRadiation.WebApi.CustomAttributes;

namespace TechnicalRadiation.WebApi.Controllers
{
    [Route("/api")]
    [ApiController]
    public class NewsItemController : ControllerBase
    {
        NewsItemService _newsItemService;
        public NewsItemController(IMapper mapper) {
            _newsItemService = new NewsItemService(mapper);
        }

        //http://localhost:5000/api [GET]
        [Route("")]
        [HttpGet]
        public IActionResult GetAllNewsItems([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 25) {
            var envelope = new Envelope<NewsItemDto>(pageNumber, pageSize, _newsItemService.GetAllNewsItems());
            return Ok(envelope);
        }
        
        //http://localhost:5000/api/1 [GET]
        [Route("{id:int}", Name = "GetNewsItemsById")] // þetta route ef ég ætla refreca þennan route í kóða
        [HttpGet]
        public IActionResult getNewsItemsById(int id) {
            
            return Ok(_newsItemService.GetNewsItemById(id));
        }
        
        /* ========== Authorized routes ===============*/
        //http://localhost:5000/api [POST]
        [Route("")]
        [HttpPost]
        [ApiKeyAuthorization]
        public IActionResult CreateNewsItem([FromBody] NewsItemInputModel body)  { 
            if(!ModelState.IsValid) { return BadRequest("Data was not properly formatted."); }
            var newNewsItem = _newsItemService.CreateNewsItem(body);
            return CreatedAtRoute("GetNewsItemsById", new { id = newNewsItem.Id }, null);
        }

        //http://localhost:5000/api/newsItems/1 [PUT]
        [ApiKeyAuthorization]
        [Route("{id:int}")]
        [HttpPut]
        public IActionResult UpdateNewsItemByID([FromBody] NewsItemInputModel body, int id) {
            if(!ModelState.IsValid) { return BadRequest("Data was not properly formatted."); }
            _newsItemService.UpdateNewsItemByID(body, id);
            return NoContent();
        }

        //http://localhost:5000/api/newsItems/1 [DELETE]
        [ApiKeyAuthorization]
        [Route("{id:int}")]
        [HttpDelete]
        public IActionResult DeleteNewsItemById(int id) {

            _newsItemService.DeleteNewsItemById(id);
            return NoContent();
        }
    }
}
