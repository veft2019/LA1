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
    public class NewsItemRepository
    {
        private IMapper _mapper;
        public NewsItemRepository(IMapper mapper) {
            _mapper = mapper;
        }

        public IEnumerable<NewsItemDto> GetAllNewsItems() {
            return NewsItemDataProvider.NewsItems.OrderByDescending(n => n.PublishDate)
            .Select(n => _mapper.Map<NewsItemDto>(n));
        }

        public NewsItemDetailDto GetNewsItemById(int newsItemId) {
            var newsItem = NewsItemDataProvider.NewsItems.FirstOrDefault(n => n.Id == newsItemId);
            if(newsItem == null) { throw new ContentNotFoundException("Content not found!"); }
            return _mapper.Map<NewsItemDetailDto>(newsItem);
        }

        public NewsItemDto CreateNewsItem(NewsItemInputModel body) {
            var entity = _mapper.Map<NewsItem>(body);
            var nextId = NewsItemDataProvider.NewsItems.Last().Id + 1;
            entity.Id = nextId;
            NewsItemDataProvider.NewsItems.Add(entity);
            return _mapper.Map<NewsItemDto>(entity);
        }

        public void UpdateNewsItemByID(NewsItemInputModel body, int id) {
            var entity = NewsItemDataProvider.NewsItems.Where(n => n.Id == id).First();
            
            //Update props
            entity.Title = body.Title;
            entity.ImgSource = body.ImgSource;
            entity.LongDescription = body.LongDescription;
            entity.ShortDescription = body.ShortDescription;
            entity.PublishDate = body.PublishDate;
        }

         public void DeleteNewsItemById(int id) {
            var entity = NewsItemDataProvider.NewsItems.FirstOrDefault(r => r.Id == id);
            NewsItemDataProvider.NewsItems.Remove(entity);
        }
    }
}