using System.Collections.Generic;
using System.Linq;
using finance_home_system.Products;
using System;
using finance_home_system.Category;
using Api.Contexts;

namespace CategoryApi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        static List<Products> ProductsList = new List<Products>();
        Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }
        public IEnumerable<categoryList> GetCategory()
        {
            return _context.categoryList.ToList();
        }
    }
}