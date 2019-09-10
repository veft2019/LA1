using System.Collections.Generic;
using TechnicalRadiation.Models.Entities;

namespace TechnicalRadiation.Repositories.Data
{
    public class AuthorNewsItemLinkDataProvider
    {
        public static List<NewsItemAuthors> AuthorNewsItemLink = new List<NewsItemAuthors>
        {
            new NewsItemAuthors {
                AuthorId = 2,
                NewsItemId = 2
            },
            new NewsItemAuthors {
                AuthorId = 3,
                NewsItemId = 3
            }
        };
    }
}