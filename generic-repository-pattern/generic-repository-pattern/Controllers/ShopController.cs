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
        private IGenericRepository<Shop> _shopRepository;

        public ShopController(IGenericRepository<Shop> shopRepository)
        {
            _shopRepository = shopRepository;
        }
        [HttpGet]
        [Route("all-shops")]
        public async Task<ActionResult<IEnumerable<Shop>>> GetAllShops()
        {
            return Ok(await _shopRepository.GetAllAsync());
        }
        [HttpPost]
        [Route("add-shop")]
        [AllowAnonymous]
        public async Task<IActionResult> AddShop([FromBody] Shop shop)
        {
            _shopRepository.Add(shop);
            return await _shopRepository.SaveChangesAsync()? Ok(shop):Ok("Could not add shop");
        }
        [HttpGet]
        [Route("GetShopByName/{shopName}")]
        public async Task<ActionResult<Customer>> GetProductByName(string shopName)
        {
            return Ok(await _shopRepository.FindByConditionAsync(a => a.ShopName == shopName));
        }

        [HttpGet]
        [Route("GetShopById/{id}")]
        public async Task<ActionResult<Customer>> GetProductByName(int id)
        {
            return Ok(await _shopRepository.GetByIdAsync(id));
        }
    }
}
