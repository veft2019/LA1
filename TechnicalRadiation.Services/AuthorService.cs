using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.Extensions;
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
                a.Links.AddReference("self", $"/api/categories{a.Id}");
                a.Links.AddReference("edit", $"/api/categories{a.Id}");
                a.Links.AddReference("delete", $"/api/categories{a.Id}");
            });
            return authors;
        }

        public AuthorDetailDto GetAuthorById(int id) {
            var author = _authorRepo.GetAuthorById(id);
            author.Links.AddReference("self", $"/api/categories{author.Id}");
            author.Links.AddReference("edit", $"/api/categories{author.Id}");
            author.Links.AddReference("delete", $"/api/categories{author.Id}");
            return author;
        }

        public List<NewsItemDto> GetNewsItemsByAuthorId(int id) {
            var newsItems = _authorRepo.GetNewsItemsByAuthorId(id).ToList();
            //Connections???
            return newsItems;
        }
    }
}