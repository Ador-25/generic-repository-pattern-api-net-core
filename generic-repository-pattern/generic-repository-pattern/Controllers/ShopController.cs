using generic_repository_pattern.Data;
using generic_repository_pattern.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace generic_repository_pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private IGenericRepository<Shop> _productRepository;

        public ShopController(IGenericRepository<Shop> productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        [Route("all-shops")]
        public async Task<ActionResult<IEnumerable<Shop>>> GetAllCustomers()
        {
            return Ok(await _productRepository.GetAllAsync());
        }
        [HttpPost]
        [Route("add-shop")]
        [AllowAnonymous]
        public async Task<IActionResult> AddProduct([FromBody] Shop shop)
        {
            _productRepository.Add(shop);

            return Ok(await _productRepository.SaveChangesAsync());
        }
        [HttpGet]
        [Route("GetShopByName/{productName}")]
        public async Task<ActionResult<Customer>> GetProductByName(string productName)
        {
            return Ok(await _productRepository.FindByConditionAsync(a => a.ShopName == productName));
        }
    }
}
