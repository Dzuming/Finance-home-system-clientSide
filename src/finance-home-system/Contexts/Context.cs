using finance_home_system.Category;
using finance_home_system.Products;
using Microsoft.EntityFrameworkCore;

namespace Api.Contexts
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options)
            : base(options) { }
        public Context() { }
        public DbSet<categoryList> categoryList { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}