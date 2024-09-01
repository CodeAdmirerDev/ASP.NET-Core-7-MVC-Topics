using Microsoft.AspNetCore.Mvc;
using TagHelpersInASPNETCoreMVC.Models.ViewComponents;

namespace TagHelpersInASPNETCoreMVC.ViewComponents
{
    // Defining the View Component class named 'NavigationBarViewComponent' that inherits from the 'ViewComponent' base class.
    public class NavigationBarViewComponent : ViewComponent
    {
        // The Invoke method is the entry point of the View Component.
        // It is responsible for generating the view.
        // ASP.NET Core will automatically call this method when the View Component is used in a view.
        public IViewComponentResult Invoke()
        {
            // Creating a list of MenuItem objects representing the navigation bar menu items.
            // These items are hardcoded, but in a real application, this data could be fetched from a database, API, or configuration.
            var menuItems = new List<MenuItem>
            {
                // Adding a menu item for the "Home" page. The Action is "Index", and the Controller is "Home".
                new MenuItem { Text = "Home", Action = "Index", Controller = "Home" },
                // Adding a menu item for the "Cart" page. The Action is "Cart", and the Controller is "Home".
                new MenuItem { Text = "Cart", Action = "Cart", Controller = "Home" },
                // Adding a menu item for the "Contact" page. The Action is "Contact", and the Controller is "Home".
                new MenuItem { Text = "Contact", Action = "Contact", Controller = "Home" }
            };
            // Returning the view for the View Component and passing the 'menuItems' list as the model.
            // The view will use this data to render the navigation bar in the UI.
            return View(menuItems);
        }
    }
}
