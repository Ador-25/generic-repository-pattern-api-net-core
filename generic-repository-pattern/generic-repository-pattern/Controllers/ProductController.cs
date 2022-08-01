using generic_repository_pattern.Contexts;
using generic_repository_pattern.Data;
using generic_repository_pattern.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace generic_repository_pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IGenericRepository<Product> _productRepository;
        private IGenericRepository<Shop> _shopRepository;

        public ProductController(IGenericRepository<Product> productRepository, IGenericRepository<Shop> shopRepository)
        {
            _productRepository = productRepository;
            _shopRepository = shopRepository;
        }
        [HttpGet]
        [Route("all-products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return Ok(await _productRepository.GetAllAsync());
        }

        [HttpPost]
        [Route("add-product/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> AddProduct([FromBody] Product product,int id)
        {
            product.Shop = await _shopRepository.GetByIdAsync(id);
            if (product.Shop != null)
            {
                _productRepository.Add(product);
                var temp = await _productRepository.SaveChangesAsync();
                return temp? Ok(product): Ok("Could not add product");
            }
            return Ok("Invalid shop");
            
        }
        [HttpGet]
        [Route("GetProductByName/{productName}")]
        public async Task<ActionResult<Product>> GetProductByName(string productName)
        {
            return Ok(await _productRepository.FindByConditionAsync(a => a.ProductName== productName));
        }
        [HttpGet]
        [Route("GetProductById/{productId}")]
        public async Task<ActionResult<Product>> GetProductById(int productId)
        {
            return Ok(await _productRepository.GetByIdAsync(productId));
        }
        [HttpGet]
        [Route("shop/{id}/all-products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsForShop(int id)
        {
            return Ok(await _productRepository.GetAllByConditionAsync(p => p.Shop.ShopId == id));
        }
    }
}
