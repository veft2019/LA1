using System;
using System.Collections.Generic;
using TechnicalRadiation.Models.Entities;

namespace TechnicalRadiation.Repositories.Data
{
    public class CategoryDataProvider
    {
        private static readonly string _adminName = "TechnicalRadiationAdmin";
        
        public static List<Category> Categories = new List<Category>
        {
            new Category {
                Id = 1,
                Name = "Horror",
                Slug = "horror",
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                ModifiedBy = _adminName
            },
            new Category {
                Id = 2,
                Name = "Comedy",
                Slug = "comdey",
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                ModifiedBy = _adminName
            }
        };
    }
}