using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDemo
{
    public delegate void StockControl();

    public class Product
    {
        private int _stock;

        public Product(int stock,string productName)
        {
            _stock = stock;
            productName = ProductName;
        }

        public event StockControl StockControlEvent;
        public string ProductName { get; set; }

        public int StockCount
        {
            get { return _stock; }
            set
            {
                _stock = value;
                if (value <= 15 && StockControlEvent != null)
                {
                    StockControlEvent();
                }
            }
        }

        public void Sell(int amount)
        {
            StockCount -= amount;
            Console.WriteLine($"Stock Amount : {StockCount}");
        }

        public void AddProduct(Product product, int stockAmount)
        {
            product.StockCount += stockAmount;
        }

    }
}
