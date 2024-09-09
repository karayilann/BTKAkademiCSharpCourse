using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Northwind.DataAcces.Abstract;
using Northwind.Entities.Concrete;

namespace Northwind.DataAcces.Concrete.EntitiyFramework
{
    public class EfProductDal :EfEntityRepositoryBase<Product,NorthwindContext>, IProductDal
    {
       
    }
}
