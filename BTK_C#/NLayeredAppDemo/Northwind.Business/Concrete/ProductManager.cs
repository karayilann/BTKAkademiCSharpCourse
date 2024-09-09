using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Business.Abstract;
using Northwind.DataAcces.Abstract;
using Northwind.DataAcces.Concrete;
using Northwind.DataAcces.Concrete.EntitiyFramework;
using Northwind.Entities.Concrete;

namespace Northwind.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _efProductDal;
        
        public ProductManager(IProductDal efProductDal)
        {
            _efProductDal = efProductDal;
        }

        public List<Product> GetAll()
        {
            // Business side codes

            return _efProductDal.GetAllProducts();
        }

    }
}
