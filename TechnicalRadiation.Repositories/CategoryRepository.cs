using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories.Data;

namespace TechnicalRadiation.Repositories
{
    public class CategoryRepository
    {
        private IMapper _mapper;
        public CategoryRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
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

        public CategoryDto CreateCategory(CategoryInputModel body) {
            var entity = _mapper.Map<Category>(body);
            var nextId = CategoryDataProvider.Categories.Last().Id + 1;
            entity.Id = nextId;
            entity.Slug = entity.Name.Replace(' ', '-').ToLower();
            CategoryDataProvider.Categories.Add(entity);
            return _mapper.Map<CategoryDto>(entity);
        }
    }
}