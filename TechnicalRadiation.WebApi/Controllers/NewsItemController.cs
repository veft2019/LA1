using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Services;

namespace TechnicalRadiation.WebApi.Controllers
{
    [Route("api/news")]
    [ApiController]
    public class NewsItemController : ControllerBase
    {
        NewsItemService newsItemService = new NewsItemService();
         //http://localhost:5000/api/newsItems  [GET]
        [Route("")]
        [HttpGet] 

       public IActionResult GetAllNewsItems([FromQuery] int pageNumber, [FromQuery] int pageSize) {
           var envelope = new Envelope<NewsItemDto>(pageNumber, pageSize, newsItemService.GetAllNewsItems());
           return Ok(envelope);
       }
        
        //http://localhost:5000/api/newsItems/1 [GET]
        [Route("{id:int}", Name = "GetNewsItemsById")] // þetta route ef ég ætla refreca þennan route í kóða
        [HttpGet]
        public IActionResult getNewsItemsById(int id) {
            return Ok();
        }

        //http://localhost:5000/api/newsItems/ [POST]
        [Route("")]
        [HttpPost]
        public IActionResult CreateNewsItem()  { 
            return Ok();
        }

         //http://localhost:5000/api/newsItems/1 [PUT]
        [Route("{id:int}")]
        [HttpPut]
        public IActionResult UpdateNewsItemByID() {
            return Ok();
        }

         //http://localhost:5000/api/newsItems/1 [PATCH]
        [Route("{id:int}")]
        [HttpPatch]
        public IActionResult UpdateNewsItemPartiallyById(int id) {
            return Ok();
        }

         //http://localhost:5000/api/newsItems/1 [DELATE]
        [Route("{id:int}")]
        [HttpDelete]
        public IActionResult DeleteNewsItemById() {
            return Ok();
        }
    }
}
