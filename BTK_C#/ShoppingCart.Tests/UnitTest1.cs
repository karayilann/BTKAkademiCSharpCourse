using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ShoppingCart.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private CartManager _cartManager;
        private CartItem _cartItem;

        [TestInitialize]
        public void InitTests() // Bu method her testten önce çağırıldığı için ortak olan kodları yazdık
        {
            _cartManager = new CartManager();
            _cartItem = new CartItem
            {
                Product = new Product
                {
                    Id = 1,
                    Name = "Laptop",
                    UnitPrice = 1000
                },
                Quantity = 1
            };
            _cartManager.AddItem(_cartItem);
        }

        [TestCleanup]
        public void CleanupTests()
        {
            _cartManager.Clear(); // Örnek amaçlı olarak yazıldı. InitTests kısmında newlendiğinde zaten temizleniyor
        }


        [TestMethod]
        public void SepeteUrunEklenebilmeTesti()
        {
            var expectedResult = 1;

            var happened = _cartManager.TotalItems;
            Assert.AreEqual(expectedResult, happened);
        }

        [TestMethod]
        public void SepettenUrunCıkarilabilmeli()
        {
            var expectedResult = 0;
            
            _cartManager.RemoveItem(1);
            var happened = _cartManager.TotalItems;
            Assert.AreEqual(expectedResult,happened);
        }

        [TestMethod]
        public void SepetTemizlenebilmelidir()
        {
          var expectedResult = 0;
           
           _cartManager.Clear();
           var happened = _cartManager.TotalItems;
           Assert.AreEqual(expectedResult, happened);
        }
    }
}
