using finance_home_system.Category;
using finance_home_system.Products;
using System.Collections.Generic;

namespace ProductsApi.Repository
{
    public interface IProductsRepository
    {
        void Add(Products item);
        IEnumerable<object> GetAll();
        Products Find(string key);
        void Remove(string Id);
        void Update(Products item);
    }
}
