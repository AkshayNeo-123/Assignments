using MVCCoreProductAppWithList.Models;

namespace MVCCoreProductAppWithList.Repository
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
    }
}
