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
        private ApplicationDbContext _context;

        public ProductController(IGenericRepository<Product> productRepository, ApplicationDbContext context)
        {
            _productRepository = productRepository;
            _context=context;
        }
        [HttpGet]
        [Route("all-products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllCustomers()
        {
            return Ok(await _productRepository.GetAllAsync());
        }

        [HttpPost]
        [Route("add-product/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> AddProduct([FromBody] Product product,int id)
        {
            product.Shop = _context.Shops.Find(id);
            if (product.Shop != null)
            {
                _productRepository.Add(product);
                return Ok(await _productRepository.SaveChangesAsync());
            }
            return Ok("Could not add product");
            
        }
        [HttpGet]
        [Route("GetProductByName/{productName}")]
        public async Task<ActionResult<Customer>> GetProductByName(string productName)
        {
            return Ok(await _productRepository.FindByConditionAsync(a => a.ProductName== productName));
        }
    }
}
