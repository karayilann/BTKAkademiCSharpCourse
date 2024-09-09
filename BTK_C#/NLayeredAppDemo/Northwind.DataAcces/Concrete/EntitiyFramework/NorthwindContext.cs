using System.Data.Entity;
using Northwind.Entities.Concrete;

namespace Northwind.DataAcces.Concrete.EntitiyFramework
{
    public class NorthwindContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
