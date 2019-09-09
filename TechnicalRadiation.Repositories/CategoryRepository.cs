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
        }

        public CategoryDetailDto GetCategoryById(int id) {
            var category = CategoryDataProvider.Categories.FirstOrDefault(c => c.Id == id);
            if(category == null) { return null; } //throw exception
            return new CategoryDetailDto {
                Id = category.Id,
                Name = category.Name,
                Slug = category.Slug,
                NumberOfNewsItems = 0 //Make a methood to find all news items with this category and return length 
            };
            //MAPPER REQUIRED
        }
    }
}