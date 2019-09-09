using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
                c.Links.AddReference("self", $"/api/categories/{c.Id}");
                c.Links.AddReference("edit", $"/api/categories/{c.Id}");
                c.Links.AddReference("delete", $"/api/categories/{c.Id}");
            });
            return categories;
        }

        public CategoryDetailDto GetCategoryById(int id) {
            var category = _categoryRepo.GetCategoryById(id);
            category.Links.AddReference("self", $"/api/categories/{category.Id}");
            category.Links.AddReference("edit", $"/api/categories/{category.Id}");
            category.Links.AddReference("delete", $"/api/categories/{category.Id}");
            return category;
        }

        public CategoryDto CreateCategory(CategoryInputModel body) {
            return _categoryRepo.CreateCategory(body);
        }
    }
}