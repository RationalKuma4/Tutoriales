using System.Collections.Generic;

namespace CoreMvcThree.Model
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
        new List<Category>
        {
            new Category{CategoryId = 1,CategoryName = "Fruit pies",Description = "Fruits"},
            new Category{CategoryId = 2,CategoryName = "Cheese pies",Description = "Cheese"},
            new Category{CategoryId = 3,CategoryName = "Seasonal pies",Description = "Seasonal"}
        };
    }
}
