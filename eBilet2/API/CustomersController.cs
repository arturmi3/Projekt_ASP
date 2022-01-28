using Microsoft.AspNetCore.Mvc;

using eBilet2.Models;

namespace eBilet2.API
{
    [Route("/api/customers")]
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        [Route("id")]
        public IActionResult Get(int id)
        {
            var c = _customerRepository.LoadCustomer(id);
            return new ObjectResult(c);
        }
    }
}