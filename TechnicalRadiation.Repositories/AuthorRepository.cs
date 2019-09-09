using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories.Data;

namespace TechnicalRadiation.Repositories
{
    public class AuthorRepository
    {
        private IMapper _mapper;
        public AuthorRepository(IMapper mapper) {
            _mapper = mapper;
        }
        public IEnumerable<AuthorDto> GetAllAuthors() {
            return AuthorDataProvider.Authors.Select(a => new AuthorDto {
                Id = a.Id,
                Name = a.Name
            });
            //MAPPER REQUIRED
        }

        public AuthorDetailDto GetAuthorById(int id) {
            var author = AuthorDataProvider.Authors.FirstOrDefault(a => a.Id == id);
            if(author == null) { return null; } //throw exception
            return new AuthorDetailDto {
                Id = author.Id,
                Name = author.Name,
                ProfileImgSoruce = author.ProfileImageSource,
                Bio = author.Bio
            };
            //MAPPER REQUIRED
        }

        public IEnumerable<NewsItemDto> GetNewsItemsByAuthorId(int id) {
            //var newsItems = NewsItemDataProvider.NewsItems.Where()
            return new List<NewsItemDto> {};
        }

        public AuthorDto CreateAuthor(AuthorInputModel body) {
            var entity = _mapper.Map<Author>(body);
            var nextId = AuthorDataProvider.Authors.Last().Id + 1;
            entity.Id = nextId;
            AuthorDataProvider.Authors.Add(entity);
            return _mapper.Map<AuthorDto>(entity);
        }
    }
}