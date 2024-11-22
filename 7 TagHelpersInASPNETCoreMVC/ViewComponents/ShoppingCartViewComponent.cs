using Microsoft.AspNetCore.Mvc;
using TagHelpersInASPNETCoreMVC.Models.Services;

namespace TagHelpersInASPNETCoreMVC.ViewComponents
{
    // Defining a ViewComponent class named 'ShoppingCartViewComponent' that inherits from the 'ViewComponent' base class.
    public class ShoppingCartViewComponent : ViewComponent
    {
        // Declaring a private readonly field of type 'CartService' to store the injected service for accessing cart-related data.
        private readonly CartService _cartService;
        // Constructor for the ShoppingCartViewComponent class that takes an instance of 'CartService' as a parameter.
        // ASP.NET Core will use Dependency Injection to provide an instance of CartService when creating this ViewComponent.
        public ShoppingCartViewComponent(CartService cartService)
        {
            // Storing the injected CartService instance in the private field '_cartService' to access cart data within the class.
            _cartService = cartService;
        }
        // The Invoke method is the entry point of the ViewComponent. ASP.NET Core automatically calls this method when the ViewComponent is used in a view.
        public IViewComponentResult Invoke()
        {
            // Using the CartService instance to retrieve the list of items currently in the shopping cart.
            var cartItems = _cartService.GetCartItems();
            // Returning the view for the ShoppingCartViewComponent, passing the 'cartItems' list as the model.
            // The view will use this data to render the shopping cart items in the UI.
            return View(cartItems);
        }
    }
}
