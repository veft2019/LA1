using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Repositories;
using TechnicalRadiation.Models.Extensions;
using TechnicalRadiation.Models.InputModels;
using AutoMapper;

namespace TechnicalRadiation.Services
{
    public class NewsItemService
    {
        private NewsItemRepository _newsItemRepo;
        private AuthorRepository _authorRepo;

        public NewsItemService(IMapper mapper) {
            _newsItemRepo = new NewsItemRepository(mapper);
            _authorRepo = new AuthorRepository(mapper);
        }

        public List<NewsItemDto> GetAllNewsItems() {
            var newsItems = _newsItemRepo.GetAllNewsItems().ToList();
            newsItems.ForEach(n => {
                n.Links.AddReference("self", $"/api/{n.Id}");
                n.Links.AddReference("edit", $"/api/{n.Id}");
                n.Links.AddReference("delete", $"/api/{n.Id}");
                //n.Links.AddListReference("authors", _authorRepo.GetAuthorsByNewsItemId(n.Id).Select(a => new {href = $"api/authors/{a.Id}/newsItems/{n.Id}"}));
                //n.Links.AddListReference("categories", _categoryRepo.GetCategoriesByNewsItemId(n.Id).Select(c => new {href = $"api/categories/{c.Id}/newsItems/{n.Id}"}));
            });

            return newsItems;
        }

        public NewsItemDetailDto GetNewsItemById(int newsItemId) {
            var newsItem = _newsItemRepo.GetNewsItemById(newsItemId);
            
            newsItem.Links.AddReference("self", $"/api/{newsItem.Id}");
            newsItem.Links.AddReference("edit", $"/api/{newsItem.Id}");
            newsItem.Links.AddReference("delete", $"/api/{newsItem.Id}");
            //newsItem.Links.AddListReference("authors", _authorRepo.GetAuthorsByNewsItemId(newsItem.Id).Select(a => new {href = $"api/authors/{a.Id}/newsItems/{newsItem.Id}"}));
            //newsItem.Links.AddListReference("categories", _categoryRepo.GetCategoriesByNewsItemId(newsItem.Id).Select(c => new {href = $"api/categories/{c.Id}/newsItems/{newsItem.Id}"}));

            return newsItem;
        }

        public NewsItemDto CreateNewsItem(NewsItemInputModel body) {
            return _newsItemRepo.CreateNewsItem(body);
        }

        public void UpdateNewsItemByID(NewsItemInputModel body, int id) {
            _newsItemRepo.UpdateNewsItemByID(body, id);
        }

         public void DeleteNewsItemById(int id) {
            _newsItemRepo.DeleteNewsItemById(id);
        }
    }
}