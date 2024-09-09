using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataAcces.Abstract;
using Northwind.Entities.Concrete;

namespace Northwind.DataAcces.Concrete.EntitiyFramework
{
    public class EfCategoryDal:EfEntityRepositoryBase<Category,NorthwindContext>,ICategoryDal
    {


    }
}
