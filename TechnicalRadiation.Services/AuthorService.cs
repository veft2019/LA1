using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
                a.Links.AddReference("self", $"/api/authors/{a.Id}");
                a.Links.AddReference("edit", $"/api/authors/{a.Id}");
                a.Links.AddReference("delete", $"/api/authors/{a.Id}");
            });
            return authors;
        }

        public AuthorDetailDto GetAuthorById(int id) {
            var author = _authorRepo.GetAuthorById(id);
            author.Links.AddReference("self", $"/api/authors/{author.Id}");
            author.Links.AddReference("edit", $"/api/authors/{author.Id}");
            author.Links.AddReference("delete", $"/api/authors/{author.Id}");
            return author;
        }

        public List<NewsItemDto> GetNewsItemsByAuthorId(int id) {
            var newsItems = _authorRepo.GetNewsItemsByAuthorId(id).ToList();
            //Connections???
            return newsItems;
        }

<<<<<<< HEAD
        public AuthorDto CreateAuthor(AuthorInputModel body) {
            return _authorRepo.CreateAuthor(body);
        }
=======
>>>>>>> aed86cbeda717fd38b587cecaddc23907cb965b5
    }
}