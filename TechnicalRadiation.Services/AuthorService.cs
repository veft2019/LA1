using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json.Linq;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.Extensions;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories;

namespace TechnicalRadiation.Services
{
    public class AuthorService
    {
        private AuthorRepository _authorRepo;
        public AuthorService(IMapper mapper) {
            _authorRepo = new AuthorRepository(mapper);
        }

        public List<AuthorDto> GetAllAuthors() {
            var authors = _authorRepo.GetAllAuthors().ToList();
            authors.ForEach(a => {
                a.Links.AddReference("self", new JObject{new JProperty("href", $"/api/authors/{a.Id}")});
                a.Links.AddReference("edit", new JObject{new JProperty("href", $"/api/authors/{a.Id}")});
                a.Links.AddReference("delete", new JObject{new JProperty("href", $"/api/authors/{a.Id}")});
                a.Links.AddReference("newsItems", new JObject{new JProperty("href", $"/api/authors/{a.Id}/newsItems")});
                //Need List reference for authors newItemDetailed href links
            });
            return authors;
        }

        public AuthorDetailDto GetAuthorById(int id) {
            var author = _authorRepo.GetAuthorById(id);
            author.Links.AddReference("self", new JObject{new JProperty("href", $"/api/authors/{author.Id}")});
            author.Links.AddReference("edit", new JObject{new JProperty("href", $"/api/authors/{author.Id}")});
            author.Links.AddReference("delete", new JObject{new JProperty("href", $"/api/authors/{author.Id}")});
            author.Links.AddReference("newsItems", new JObject{new JProperty("href", $"/api/authors/{author.Id}/newsItems")});
            //Need List reference for authors newItemDetailed href links
            return author;
        }

        public List<NewsItemDto> GetNewsItemsByAuthorId(int id) {
            var newsItems = _authorRepo.GetNewsItemsByAuthorId(id).ToList();
            newsItems.ForEach(n => {
                n.Links.AddReference("self", new JObject{new JProperty("href", $"/api/{n.Id}")});
                n.Links.AddReference("edit", new JObject{new JProperty("href", $"/api/{n.Id}")});
                n.Links.AddReference("delete", new JObject{new JProperty("href", $"/api/{n.Id}")});
                //n.Links.AddListReference("authors", _authorRepo.GetAuthorsByNewsItemId(n.Id).Select(a => new { href = $"api/authors/{a.Id}/newsItems/{n.Id}"}));
                //n.Links.AddListReference("categories", _categoryRepo.GetCategoriesByNewsItemId(n.Id).Select(c => new { href = $"api/categories/{c.Id}/newsItems/{n.Id}"}));
            });
            return newsItems;
        }

        public AuthorDto CreateAuthor(AuthorInputModel body) {
            return _authorRepo.CreateAuthor(body);
        }

        public void UpdateAuthorById(AuthorInputModel body, int id) {
            _authorRepo.UpdateAuthorById(body, id);
        }

        public void DeleteAuthorById(int id) {
            _authorRepo.DeleteAuthorById(id);
        }
    }
}