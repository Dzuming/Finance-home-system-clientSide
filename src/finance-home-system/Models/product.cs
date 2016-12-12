using finance_home_system.Categories;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace finance_home_system.Products
{
    public class Product: IEntityBase
    {
        
        public int Id { get; set; }
        public string Name { get; set; }

        public int categoryId { get; set; }
        [ForeignKey("categoryId")]
        public virtual Category categories { get; set; }
        public int Spending { get; set; }
        public DateTime DateCreated { get; set; }
    }
}

