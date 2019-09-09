using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories.Data;

namespace TechnicalRadiation.Repositories
{
    public class NewsItemRepository
    {
        private IMapper _mapper;
        public NewsItemRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<NewsItemDto> GetAllNewsItems() {
            return NewsItemDataProvider.NewsItems.OrderBy(n => n.PublishDate)
            .Select(n => new NewsItemDto {
                Id = n.Id,
                Title = n.Title,
                ImgSource = n.ImgSource,
                ShortDescription = n.ShortDescription
            });
            //MAPPER REQUIRED
        }

        public NewsItemDetailDto GetNewsItemById(int newsItemId) {
            var newsItem = NewsItemDataProvider.NewsItems.FirstOrDefault(n => n.Id == newsItemId);
            if(newsItem == null) { return null; } //Throw exception
            return new NewsItemDetailDto {
                Id = newsItem.Id,
                Title = newsItem.Title,
                ImgSource = newsItem.ImgSource,
                ShortDescription = newsItem.ShortDescription,
                LongDescription = newsItem.LongDescription,
                PublishDate = newsItem.PublishDate
            };
            //MAPPER REQUIRED
        }

        public NewsItemDto CreateNewsItem(NewsItemInputModel body) {
            var entity = _mapper.Map<NewsItem>(body);
            var nextId = NewsItemDataProvider.NewsItems.Last().Id + 1;
            entity.Id = nextId;
            NewsItemDataProvider.NewsItems.Add(entity);
            return _mapper.Map<NewsItemDto>(entity);
        }

         public void DeleteNewsItemById(int id) {
            var entity = NewsItemDataProvider.NewsItems.FirstOrDefault(r => r.Id == id);
            if (entity == null) { return; /* remember exception */ }
            NewsItemDataProvider.NewsItems.Remove(entity);
        }
    }
}