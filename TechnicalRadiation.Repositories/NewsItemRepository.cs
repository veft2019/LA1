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
            return NewsItemDataProvider
            .NewsItems
            .OrderBy(n => n.PublishDate)
            .Select(n => new NewsItemDto {
                Id = n.Id,
                Title = n.Title,
                ImgSource = n.ImgSource,
                ShortDescription = n.ShortDescription
            });
        }
    }
}