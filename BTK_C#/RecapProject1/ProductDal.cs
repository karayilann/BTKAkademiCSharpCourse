using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecapProject1.Entities;

namespace RecapProject1
{
    public class ProductDal
    {
        public List<Product> GetAllProducts()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
               return context.Products.ToList();
            }
        }

        public List<Category> GetCategories()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Categories.ToList();
            }
        }

        public List<Product> GetProductsByCategories(int categoryId)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Products.Where(p => p.CategoryId == categoryId).ToList();
            }
        }

        public List<Product> GetProductsByName(string key)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Products.Where(p => p.ProductName.Contains(key)).ToList();
            }
        }


    }
}
