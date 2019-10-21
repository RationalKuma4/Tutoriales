using System.Collections.Generic;

namespace CoreMvcThree.Model
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> AllCategories => _context.Categories;
    }
}
