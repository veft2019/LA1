using System.Collections.Generic;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Repositories;

namespace TechnicalRadiation.Services
{
    public class NewsItemService
    {
        private NewsItemRepository _newsItemRepo = new NewsItemRepository();

        public IEnumerable<NewsItemDto> GetAllNewsItems() {
            return _newsItemRepo.GetAllNewsItems();
        }
    }
}