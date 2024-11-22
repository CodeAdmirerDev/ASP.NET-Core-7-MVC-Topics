namespace TypesOfViewsInASPNETCore.Models.Repository
{
    public class ProductRepository
    {

        public async Task<List<Product>> GetPopularProductsAsync(int NoOfProducts)
        {

            IEnumerable<Product> products = new List<Product>(){ new Product() { Description="Good" , IsInStock=true,
            ProdcutId=1,ProdcutName="SmartPhone", Rating=5},
            
            new Product() { Description="Good" , IsInStock=true,
            ProdcutId=2,ProdcutName="HeadPhone", Rating=5},
            new Product() { Description="Good" , IsInStock=true,
            ProdcutId=3,ProdcutName="laptop", Rating=5},

            new Product() { Description="Good" , IsInStock=true,
            ProdcutId=4,ProdcutName="SmartWatch", Rating=5},
            new Product() { Description="Good" , IsInStock=true,
            ProdcutId=5,ProdcutName="Tab", Rating=5}
            };

            await Task.Delay(TimeSpan.FromSeconds(10));
            return products.Take(NoOfProducts).ToList();

        }
    }
}
