using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Ninject.Modules;
using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.Business.ValidationRules;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework;

namespace Northwind.Business.DependecyResolvers.Ninject
{
    public class BusinessModel: NinjectModule
    {
        public override void Load()
        {
            // .InSingletonScope() Bu kod ile her istekte aynı instance oluşturulur.
            // .InTransientScope() Bu kod ile her istekte yeni bir instance oluşturulur.
            // .InRequestScope() Bu kod ile her requestte aynı instance oluşturulur.
            // .InThreadScope() Bu kod ile her threadte aynı instance oluşturulur.
            // .InScope(Func<IContext, object> scope) Bu kod ile belirli bir scope içinde aynı instance oluşturulur.
            // .InNamedScope(string scopeName) Bu kod ile belirli bir scope içinde aynı instance oluşturulur.
            // .InCallScope() Bu kod ile her çağrıda aynı instance oluşturulur.


            // Bu tarz instanceler oluşturan yapılara IOC (Inversion of Control) Container denir. 
            // IOC Container, bir sınıfın instance'ını oluştururken, bu sınıfın bağımlılıklarını da otomatik olarak çözer.
            // https://gokhan-gokalp.com/ioc-container-nedir/ Bu Linkte örnek olarak kendisi yazmakta

            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();
            
            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();

        }
    }
}
