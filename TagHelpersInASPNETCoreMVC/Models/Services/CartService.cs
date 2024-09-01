using TagHelpersInASPNETCoreMVC.Models.ViewComponents;

namespace TagHelpersInASPNETCoreMVC.Models.Services
{
    public class CartService
    {
        private static List<CartItem> _cartItems = new List<CartItem>();
        public IEnumerable<CartItem> GetCartItems()
        {
            return _cartItems;
        }
        public void AddToCart(TagHelpersInASPNETCoreMVC.Models.ViewComponents.Product product, int quantity)
        {
            var existingItem = _cartItems.FirstOrDefault(c => c.Product.ProductId == product.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _cartItems.Add(new CartItem { Product = product, Quantity = quantity });
            }
        }
    }
}
