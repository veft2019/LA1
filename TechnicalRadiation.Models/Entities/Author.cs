using System;

namespace TechnicalRadiation.Models.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfileImageSource { get; set; }
        public string Bio { get; set; }

        // Metadata - Database specific properties
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}