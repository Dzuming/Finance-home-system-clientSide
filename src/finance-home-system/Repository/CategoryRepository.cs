using System.Collections.Generic;
using System.Linq;
using finance_home_system.Products;
using System;
using finance_home_system.Categories;
using Api.Contexts;

namespace CategoryApi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;
        static List<Category> Category = new List<Category>();
        public CategoryRepository(Context context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetAll()
        {
            return _context.Category.AsEnumerable();
        }
    }
}