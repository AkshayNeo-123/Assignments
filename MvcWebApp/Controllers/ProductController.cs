using Microsoft.AspNetCore.Mvc;
using MVCCoreProductAppWithList.Models;
using MVCCoreProductAppWithList.Repository;

namespace MVCCoreProductAppWithList.Controllers
{
    public class ProductController : Controller
    {
        readonly IProductRepository _productRepository;
        //constructor level dependency injection
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult GetProducts()
        {
            List<Product> allProducts = _productRepository.GetProducts();
            return View(allProducts);
        }
    }
}
