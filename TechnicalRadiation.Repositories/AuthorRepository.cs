using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.Exceptions;
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
            return AuthorDataProvider.Authors.Select(a => _mapper.Map<AuthorDto>(a));
        }

        public AuthorDetailDto GetAuthorById(int id) {
            var author = AuthorDataProvider.Authors.FirstOrDefault(a => a.Id == id);
            if(author == null) { throw new ContentNotFoundException("Content not found!"); }
            return _mapper.Map<AuthorDetailDto>(author);
        }

        public IEnumerable<NewsItemDto> GetNewsItemsByAuthorId(int id) {
            var authorNewsItemLinks = AuthorNewsItemLinkDataProvider.AuthorNewsItemLink.Where(a => a.AuthorId == id);
            List<NewsItemDto> newsItems = new List<NewsItemDto>();
            foreach (var item in authorNewsItemLinks)
            {
                var entity = NewsItemDataProvider.NewsItems.FirstOrDefault(n => n.Id == item.NewsItemId);
                newsItems.Add(_mapper.Map<NewsItemDto>(entity));
            }
            if(newsItems.Count() <= 0) { throw new ContentNotFoundException("Content not found!"); }
            return newsItems;
        }

        public AuthorDto CreateAuthor(AuthorInputModel body) {
            var entity = _mapper.Map<Author>(body);
            var nextId = AuthorDataProvider.Authors.Last().Id + 1;
            entity.Id = nextId;
            AuthorDataProvider.Authors.Add(entity);
            return _mapper.Map<AuthorDto>(entity);
        }

        public void UpdateAuthorById(AuthorInputModel body, int id) {
            var entity = AuthorDataProvider.Authors.FirstOrDefault(a => a.Id == id);

            //Update props
            entity.Name = body.Name;
            entity.ProfileImageSource = body.ProfileImgSource;
            entity.Bio = body.Bio;
            entity.DateModified = DateTime.Now;
        }

        public void ConnectNewsItemToAuthor(int authorId, int newsItemId) {
            NewsItemAuthors newConnection = new NewsItemAuthors {AuthorId = authorId, NewsItemId = newsItemId};
            
            //Checking if connection is already made
            NewsItemAuthors exists = AuthorNewsItemLinkDataProvider.AuthorNewsItemLink
                                    .FirstOrDefault(i => i.NewsItemId == newsItemId && i.AuthorId == authorId);
            if(exists != null) { throw new ConnectionExistsException("Connection already exists!"); }
            AuthorNewsItemLinkDataProvider.AuthorNewsItemLink.Add(newConnection);
        }

        public IEnumerable<NewsItemAuthors> GetAuthorsByNewsItemId(int id) { 
           return AuthorNewsItemLinkDataProvider.AuthorNewsItemLink.Where(n => n.NewsItemId == id);
        }

        public void DeleteAuthorById(int id) {
            var entity = AuthorDataProvider.Authors.FirstOrDefault(r => r.Id == id);
            AuthorDataProvider.Authors.Remove(entity);
        }

    }
}