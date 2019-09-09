using System;
using System.Collections.Generic;
using TechnicalRadiation.Models.Entities;

namespace TechnicalRadiation.Repositories.Data
{
    public class AuthorDataProvider
    {
        private static readonly string _adminName = "TechnicalRadiationAdmin";
        
        public static List<Author> Authors = new List<Author>
        {
            new Author {
                Id = 1,
                Name = "Jerry Smith",
                ProfileImageSource = "https://pbs.twimg.com/media/D1bJ29IVYAA1yyV.jpg",
                Bio = "Crazy dude sipping a cup of tea all the time.",
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                ModifiedBy = _adminName
            },
            new Author {
                Id = 2,
                Name = "Literally Death",
                ProfileImageSource = "https://i.pinimg.com/originals/dc/55/a0/dc55a0fec14d93d9cf6fa32c32f7c7f2.jpg",
                Bio = "Deadly serious about his writing.",
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                ModifiedBy = _adminName
            },
            new Author {
                Id = 3,
                Name = "Snoopy Snoop",
                ProfileImageSource = "https://pbs.twimg.com/media/Dyg-PgCXgAE2QKZ.jpg",
                Bio = "Overall chill guy.",
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                ModifiedBy = _adminName
            },
            new Author {
                Id = 4,
                Name = "Lisa Simpson",
                ProfileImageSource = "https://pbs.twimg.com/profile_images/1036730403514736650/PCRxFiEt_400x400.jpg",
                Bio = "She doesn't mess around when it comes to books.",
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                ModifiedBy = _adminName
            }
        };
    }
}