using finance_home_system.Categories;
using System.Collections.Generic;

namespace CategoryApi.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
    }
}
