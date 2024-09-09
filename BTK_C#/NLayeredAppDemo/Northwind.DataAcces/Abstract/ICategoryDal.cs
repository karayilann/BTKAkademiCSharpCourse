using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Entities.Concrete;

namespace Northwind.DataAcces.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
    }
}
