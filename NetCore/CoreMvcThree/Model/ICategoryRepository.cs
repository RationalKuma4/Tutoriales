using System.Collections.Generic;

namespace CoreMvcThree.Model
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
