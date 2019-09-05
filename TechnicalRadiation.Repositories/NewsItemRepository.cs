using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Repositories.Data;

namespace TechnicalRadiation.Repositories
{
    public class NewsItemRepository
    {
        public IEnumerable<NewsItemDto> GetAllNewsItems() {
            return NewsItemDataProvider.NewsItems.OrderBy(n => n.PublishDate);
        }
    }
}