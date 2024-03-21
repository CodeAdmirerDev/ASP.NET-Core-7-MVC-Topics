using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using TypesOfViewsInASPNETCore.Models.Repository;

namespace TypesOfViewsInASPNETCore.ViewComponents
{
    public class PopularProductsViewComponent : ViewComponent
    {

        //public IViewComponentResult Invoke(int NoOfProducts)
        //{
        //    ProductRepository productRepository = new ProductRepository();

        //    var productsInfo =    productRepository.GetPopularProductsAsync(NoOfProducts).Result;

        //    return View(productsInfo);
        //}

        public async  Task<IViewComponentResult> InvokeAsync(int NoOfProducts)
        {
            ProductRepository productRepository = new ProductRepository();

            var productsInfo = productRepository.GetPopularProductsAsync(NoOfProducts).Result;

            return View(productsInfo);
        }


    }
}
