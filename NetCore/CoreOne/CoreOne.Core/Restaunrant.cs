using System.ComponentModel.DataAnnotations;

namespace CoreOne.Core
{
    public class Restaunrant
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
