using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntitiyFrameworkDemo
{
    public class ProductDal
    {

        /// <summary>
        /// Databaseden veri çeker
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAll()
        {
            // Eğer using kullanmazsak Garbage Collector silene kadar kalmaya devam edecek bu işlem bittikten sonra Dispose etmesini sağlıyoruz.
            using (ETradeContext context = new ETradeContext())
            {
                // Veritabanına erişme methodunu kullanmak için App.config içinde ETradeContext adı ile açılan connection stringe erişim sağlar.
                return context.Products.ToList();
            }
        }

        public void AddObject(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                //context.Products.Add(product);
                var entitiy = context.Entry(product);
                entitiy.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void DeleteObject(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entitiy = context.Entry(product);
                entitiy.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void UpdateObject(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                // Bu yazılan kod ile verdiğimiz parametreyi veritabanındaki ilgili ürün ile eşleştirir.
               
                var entitiy = context.Entry(product);
                entitiy.State = EntityState.Modified;
                context.SaveChanges();
            }

        }


        // Bu yöntem ile veri tabanına doğrudan sql dilinde kod yollanarak filtrelenir ve bu sayede memory ve hız kazanılır
        public List<Product> GetByName(string key)
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.Name.Contains(key)).ToList();
            }
        }

        public List<Product> GetByUnitPrice(decimal price)
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.UnitPrice >= price).ToList();
            }
        }

        public List<Product> GetByUnitPrice(decimal minPrice, decimal maxPrice)
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.UnitPrice >= minPrice && p.UnitPrice <= maxPrice).ToList();
            }
        }

        public Product GetById(int id)
        {
            using (ETradeContext context = new ETradeContext())
            {
                // İstenilen datayı bulamazsa default olanı getirir.
                return context.Products.FirstOrDefault(p => p.ID == id);
            }

        }

    }
}
