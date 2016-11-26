using System.Collections.Generic;
using System.Linq;
using finance_home_system.Products;
using Api.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ProductsApi.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        static List<Products> ProductsList = new List<Products>();
        Context _context;
        private IEnumerable<object> joinProduct;

        public ProductsRepository(Context context)
        {
            _context = context;
        }
        public void Add(Products item)
        {
            _context.Products.Add(item);
            _context.SaveChanges();
        }

        public Products Find(string key)
        {
            return ProductsList
                .Where(e => e.ProductsId.Equals(key))
                .SingleOrDefault();
        }

        public  IEnumerable<object> GetAll()
        {
            joinProduct = (from Product in _context.Products
                  join category in _context.categoryList on Product.categoryList.categoryListId equals category.categoryListId
               select new { Product.Name,  Product.Spending, category.Category });
            return joinProduct.ToList();
        }
        public void Remove(string Id)
        {
            var itemToRemove = ProductsList.SingleOrDefault(r => r.Name == Id);
            if (itemToRemove != null)
                ProductsList.Remove(itemToRemove);
        }
        
        public void Update(Products item)
        {
            var itemToUpdate = ProductsList.SingleOrDefault(r => r.ProductsId == item.ProductsId);
            if (itemToUpdate != null)
            {
                itemToUpdate.Name = item.Name;
                itemToUpdate.Spending = item.Spending;
                // itemToUpdate.categoryList = item.categoryList;
            }
        }
    }
}