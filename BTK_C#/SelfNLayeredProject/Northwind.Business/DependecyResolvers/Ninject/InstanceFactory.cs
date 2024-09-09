using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;

namespace Northwind.Business.DependecyResolvers.Ninject
{
    public class InstanceFactory
    {
        // Bu script parametre olarak verilen interface'in instance'ını döndürür.
        // Bu sayede herhangi bir class'ta instance almak için new keyword'ü kullanmamıza gerek kalmaz.
        // Aynı zamanda parametre alamayan Form1_Load gibi methotlar içinde instance alınabilir.


        public static T GetInstance<T>()
        {
            var kernel = new StandardKernel(new BusinessModel());
            return kernel.Get<T>();
        }
    }
}
