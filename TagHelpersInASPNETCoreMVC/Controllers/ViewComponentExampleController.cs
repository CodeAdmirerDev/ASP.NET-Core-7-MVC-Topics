using Microsoft.AspNetCore.Mvc;
using TagHelpersInASPNETCoreMVC.Models.Services;

namespace TagHelpersInASPNETCoreMVC.Controllers
{
    public class ViewComponentExampleController : Controller
    {
        private readonly ProductService _productService;
        private readonly CartService _cartService;
        public ViewComponentExampleController(ProductService productService, CartService cartService)
        {
            _productService = productService;
            _cartService = cartService;
        }
        public IActionResult Index()
        {
            var products = _productService.GetAllProducts();
            return View(products);
        }
        public IActionResult AddToCart(int id)
        {
            var product = _productService.GetAllProducts().FirstOrDefault(p => p.ProductId == id);
            if (product != null)
            {
                _cartService.AddToCart(product, 1);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Cart()
        {
            var cartItems = _cartService.GetCartItems();
            return View(cartItems);
        }
    }
}
