using finance_home_system.Category;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace finance_home_system.Products
{
    public class Products
    {
        public int ProductsId { get; set; }
        public string Name { get; set; }
        [ForeignKey("categoryListId")]
        public int categoryListId { get; set; }
        [JsonIgnore]
        public virtual categoryList  categoryList { get; set; }
        public int Spending { get; set; }
    }
}

