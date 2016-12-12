
using System.Collections.Generic;
using finance_home_system.Products;
namespace finance_home_system.Categories
{
    public class Category: IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
