using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.Exceptions;
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
            return CategoryDataProvider.Categories.Select(c => _mapper.Map<CategoryDto>(c));
        }

        public CategoryDetailDto GetCategoryById(int id) {
            var category = CategoryDataProvider.Categories.FirstOrDefault(c => c.Id == id);
            if(category == null) { throw new ContentNotFoundException("Content not found!"); }
            return _mapper.Map<CategoryDetailDto>(category);
        }

        public int GetNumberOfNewsItemsByCategoryId(int id) {
            int number = CategoryNewsItemLinkDataProvider.CategoryNewsItemLink.Where(c => c.CategoryId == id).Count();
            return number;
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

            //Update props
            entity.Name = body.Name;
            entity.Slug = body.Name.Replace(' ', '-').ToLower();
        }

        public void ConnectNewsItemToCategory(int categoryId, int newsItemId) {
            NewsItemCategories newConnection = new NewsItemCategories {CategoryId = categoryId, NewsItemId = newsItemId};
            
            //Checking if connection is already made
            var exists = CategoryNewsItemLinkDataProvider.CategoryNewsItemLink
                        .FirstOrDefault(i => i.NewsItemId == newsItemId && i.CategoryId == categoryId);
            if(exists != null) { throw new ContentNotFoundException("Connection already exists!"); }
            CategoryNewsItemLinkDataProvider.CategoryNewsItemLink.Add(newConnection);
        }

        public IEnumerable<NewsItemCategories> GetCategoriesByNewsItemId(int id) { 
            return CategoryNewsItemLinkDataProvider.CategoryNewsItemLink.Where(n => n.NewsItemId == id);
        }

        public void DeleteCategoriesById(int id) {
            var entity = CategoryDataProvider.Categories.FirstOrDefault(r => r.Id == id);
            CategoryDataProvider.Categories.Remove(entity);
        }
    }
}