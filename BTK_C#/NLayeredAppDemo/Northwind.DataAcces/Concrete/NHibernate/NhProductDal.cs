using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataAcces.Abstract;
using Northwind.Entities.Concrete;

namespace Northwind.DataAcces.Concrete.NHibernate
{
    public class NhProductDal : IProductDal
    {
        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts(Expression<Func<Product, bool>> filter = null)
        {
            List<Product> products = new List<Product>
            {
                new Product
                {
                    ProductId = 1, CategoryID = 1, ProductName = "Çay", QuantityPerUnit = "30", UnitPrice = 300,
                    UnitsInStock = 21
                }
            };
            return products;
        }

        public Product GetProductById(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

    }
}
