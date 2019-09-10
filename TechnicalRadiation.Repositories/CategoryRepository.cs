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

        public void UpdateCategoryById(CategoryInputModel body, int id) {
            var entity = CategoryDataProvider.Categories.FirstOrDefault(c => c.Id == id);
            if (entity == null) { return; /* Throw some exception */ }

            // Update props
            entity.Name = body.Name;
            entity.Slug = body.Name.Replace(' ', '-').ToLower();
        }

        public void ConnectNewsItemToCategory(int categoryId, int newsItemId) {
            NewsItemCategories newConnection = new NewsItemCategories {CategoryId = categoryId, NewsItemId = newsItemId};
            //Checking if connection is already made
            var exists = CategoryNewsItemLinkDataProvider.CategoryNewsItemLink
                                                         .Where(i => i.NewsItemId == newsItemId && i.CategoryId == categoryId);
            if(exists == null) { return; } //Throw exception
            CategoryNewsItemLinkDataProvider.CategoryNewsItemLink.Add(newConnection);
        }

         public void DeleteCategoriesById(int id) {
            var entity = CategoryDataProvider.Categories.FirstOrDefault(r => r.Id == id);
            if (entity == null) { return; /* remember exception */ }
            CategoryDataProvider.Categories.Remove(entity);
        }
    }
}