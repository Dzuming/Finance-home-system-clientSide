using finance_home_system.Categories;
using finance_home_system.Products;
using System.Collections.Generic;

namespace ProductsApi.Repository
{
    public interface IProductRepository
    {
        void Add(Product item);
        IEnumerable<Product> GetAll();
        Product Find(string key);
        void Remove(string Id);
        void Update(Product item);
    }
}
