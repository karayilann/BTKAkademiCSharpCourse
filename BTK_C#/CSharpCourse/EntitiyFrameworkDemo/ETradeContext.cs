using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyFrameworkDemo
{
    // Entitiy Framework'ta en öenmli kurallardan birisi database karşılık gelen bir class olmasıdır.

    // Bu classa ait bir DbContext'en türetilen bir prop oluşturulup type olarak class adı verilmeli

    public class ETradeContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

    }
}
