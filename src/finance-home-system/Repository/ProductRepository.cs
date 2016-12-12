using System.Collections.Generic;
using System.Linq;
using finance_home_system.Products;
using Api.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ProductsApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        static List<Product> ProductsList = new List<Product>();
        private readonly Context _context;
        public ProductRepository(Context context)
        {
            _context = context;
        }
        public void Add(Product item)
        {
            _context.Product.Add(item);
            _context.SaveChanges();
        }

        public Product Find(string key)
        {
            return ProductsList
                .Where(e => e.Id.Equals(key))
                .SingleOrDefault();
        }

        public  IEnumerable<Product> GetAll()
        {
                return _context.Product
                .Include(c => c.categories)
                .ToList();
        }
        public void Remove(string Id)
        {
            var itemToRemove = ProductsList.SingleOrDefault(r => r.Name == Id);
            if (itemToRemove != null)
                ProductsList.Remove(itemToRemove);
        }
        
        public void Update(Product item)
        {
            var itemToUpdate = ProductsList.SingleOrDefault(r => r.Id == item.Id);
            if (itemToUpdate != null)
            {
                itemToUpdate.Name = item.Name;
                itemToUpdate.Spending = item.Spending;
                // itemToUpdate.categoryList = item.categoryList;
            }
        }
    }
}