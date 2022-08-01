using generic_repository_pattern.Data;
using generic_repository_pattern.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace generic_repository_pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IGenericRepository<Customer> _customerRepository;
        public CustomerController(IGenericRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }
        [HttpGet]
        [Route("all-customers")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllShops()
        {
            return Ok(await _customerRepository.GetAllAsync());
        }
        [HttpPost]
        [Route("add-customer")]
        [AllowAnonymous]
        public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
        {
            _customerRepository.Add(customer);
            return await _customerRepository.SaveChangesAsync() ? Ok(customer) : Ok("Could not add shop");
        }
    }
}
