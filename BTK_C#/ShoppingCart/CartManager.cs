using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    //1. Sepete ürün eklenebilmelidir.
    //2. Sepetten ürün çıkarılabilmelidir.
    //3. Sepet temizlenebilmelidir.

    public class CartManager
    {
        private List<CartItem> _cartItems;

        public CartManager()
        {
            _cartItems = new List<CartItem>();
        }

        public void AddItem(CartItem cartItem)
        {
            _cartItems.Add(cartItem);
        }

        public void RemoveItem(int productId)
        {
            var product = _cartItems.FirstOrDefault(x => x.Product.Id == productId);
            if (product != null)
            {
                _cartItems.Remove(product);
            }
        }

        public List<CartItem> CartItems
        {
            get { return _cartItems; }
        }
        public void Clear()
        {
            _cartItems.Clear();
        }

        public decimal TotalAmount
        {
            get { return _cartItems.Sum(x => x.Product.UnitPrice * x.Quantity); }
        }

        public int TotalQuantity
        {
            get { return _cartItems.Sum(x => x.Quantity); }
        }

        public int TotalItems
        {
            get { return _cartItems.Count; }
        }

    }
}
