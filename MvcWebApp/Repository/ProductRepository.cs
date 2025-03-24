using MVCCoreProductAppWithList.Models;

namespace MVCCoreProductAppWithList.Repository
{
    public class ProductRepository : IProductRepository
    {
        //create List 
        List<Product> products;
        //constructor
        public ProductRepository()
        {
            products = new List<Product>()
            {
                new Product(){Id=1,Name="TV"}
            };
        }
        public List<Product> GetProducts()
        {
            return products;
        }
    }
}
