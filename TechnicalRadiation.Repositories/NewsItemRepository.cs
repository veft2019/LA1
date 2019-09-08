using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Repositories.Data;
using TechnicalRadiation.Models.Extensions;

namespace TechnicalRadiation.Repositories
{
    public class NewsItemRepository
    {
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
    }
}