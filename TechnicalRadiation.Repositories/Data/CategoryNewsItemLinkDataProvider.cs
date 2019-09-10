using System.Collections.Generic;
using TechnicalRadiation.Models.Entities;

namespace TechnicalRadiation.Repositories.Data
{
    public class CategoryNewsItemLinkDataProvider
    {
        public static List<NewsItemCategories> CategoryNewsItemLink = new List<NewsItemCategories>
        {
            new NewsItemCategories {
                CategoryId = 1,
                NewsItemId = 1
            },
            new NewsItemCategories {
                CategoryId = 2,
                NewsItemId = 1
            },
            new NewsItemCategories {
                CategoryId = 1,
                NewsItemId = 2
            },
        };
    }
}