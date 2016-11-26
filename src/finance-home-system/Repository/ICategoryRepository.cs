using finance_home_system.Category;
using System.Collections.Generic;

namespace CategoryApi.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<categoryList> GetCategory();
    }
}
