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
            .Select(n => _mapper.Map<NewsItemDto>(n));
            /*
            .Select(n => new NewsItemDto {
                Id = n.Id,
                Title = n.Title,
                ImgSource = n.ImgSource,
                ShortDescription = n.ShortDescription
            });
            //MAPPER REQUIRED
             */
        }

        public NewsItemDetailDto GetNewsItemById(int newsItemId) {
            var newsItem = NewsItemDataProvider.NewsItems.FirstOrDefault(n => n.Id == newsItemId);
            if(newsItem == null) { return null; } //Throw exception
            return _mapper.Map<NewsItemDetailDto>(newsItem);
            /*
            return new NewsItemDetailDto {
                Id = newsItem.Id,
                Title = newsItem.Title,
                ImgSource = newsItem.ImgSource,
                ShortDescription = newsItem.ShortDescription,
                LongDescription = newsItem.LongDescription,
                PublishDate = newsItem.PublishDate
            };
            //MAPPER REQUIRED
             */
        }

        public NewsItemDto CreateNewsItem(NewsItemInputModel body) {
            var entity = _mapper.Map<NewsItem>(body);
            var nextId = NewsItemDataProvider.NewsItems.Last().Id + 1;
            entity.Id = nextId;
            NewsItemDataProvider.NewsItems.Add(entity);
            return _mapper.Map<NewsItemDto>(entity);
        }

        public void UpdateNewsItemByID(NewsItemInputModel body, int id) {
            var newItem = _mapper.Map<NewsItem>(body);
            if (newItem == null) { return; /* Throw some exception */ }
            var oldItem = NewsItemDataProvider.NewsItems.Where(n => n.Id == id).First();

            // Update props
            // Is there a better way to do this ?
            oldItem.Title = newItem.Title;
            oldItem.ImgSource = newItem.ImgSource;
            oldItem.LongDescription = newItem.LongDescription;
            oldItem.ShortDescription = newItem.ShortDescription;
            oldItem.PublishDate = newItem.PublishDate;
        }

         public void DeleteNewsItemById(int id) {
            var entity = NewsItemDataProvider.NewsItems.FirstOrDefault(r => r.Id == id);
            if (entity == null) { return; /* remember exception */ }
            NewsItemDataProvider.NewsItems.Remove(entity);
        }
    }
}