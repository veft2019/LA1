using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Repositories.Data;

namespace TechnicalRadiation.Repositories
{
    public class CategoryRepository
    {
        public IEnumerable<CategoryDto> GetAllCategories() {
            return CategoryDataProvider.Categories.Select(c => new CategoryDto {
                Id = c.Id,
                Name = c.Name,
                Slug = c.Slug,
            });
            //MAPPER REQUIRED

            /*
            return NewsItemDataProvider.NewsItems.OrderBy(n => n.PublishDate)
            .Select(n => new NewsItemDto {
                Id = n.Id,
                Title = n.Title,
                ImgSource = n.ImgSource,
                ShortDescription = n.ShortDescription
            });
             */
            //MAPPER REQUIRED
        }
    }
}