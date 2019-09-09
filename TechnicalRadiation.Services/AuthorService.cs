using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.Extensions;
using TechnicalRadiation.Repositories;

namespace TechnicalRadiation.Services
{
    public class AuthorService
    {
        private AuthorRepository _authorRepo = new AuthorRepository();

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
    }
}