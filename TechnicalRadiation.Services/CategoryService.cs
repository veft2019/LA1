using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json.Linq;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.Extensions;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories;

namespace TechnicalRadiation.Services
{
    public class CategoryService
    {
        private CategoryRepository _categoryRepo;
        public CategoryService(IMapper mapper) {
            _categoryRepo = new CategoryRepository(mapper);
        }

        public List<CategoryDto> GetAllCategories() {
            var categories = _categoryRepo.GetAllCategories().ToList();
            categories.ForEach(c => {
                c.Links.AddReference("self", new JObject{new JProperty("href", $"/api/categories/{c.Id}")});
                c.Links.AddReference("edit", new JObject{new JProperty("href", $"/api/categories/{c.Id}")});
                c.Links.AddReference("delete", new JObject{new JProperty("href", $"/api/categories/{c.Id}")});
            });
            return categories;
        }

        public CategoryDetailDto GetCategoryById(int id) {
            var category = _categoryRepo.GetCategoryById(id);
            category.Links.AddReference("self", new JObject{new JProperty("href", $"/api/categories/{category.Id}")});
            category.Links.AddReference("edit", new JObject{new JProperty("href", $"/api/categories/{category.Id}")});
            category.Links.AddReference("delete", new JObject{new JProperty("href", $"/api/categories/{category.Id}")});
            category.NumberOfNewsItems = _categoryRepo.GetNumberOfNewsItemsByCategoryId(id);
            return category;
        }

        public CategoryDto CreateCategory(CategoryInputModel body) {
            return _categoryRepo.CreateCategory(body);
        }

        public void UpdateCategoryById(CategoryInputModel body, int id) {
            _categoryRepo.UpdateCategoryById(body, id);
        }

        public void ConnectNewsItemToCategory(int categoryId, int newsItemId) {
            _categoryRepo.ConnectNewsItemToCategory(categoryId, newsItemId);
        }

         public void DeleteCategoriesById(int id) {
            _categoryRepo.DeleteCategoriesById(id);
        }
    }
}