using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApp.CustomerData;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomer _customer;

        public CustomerController(ICustomer customer)
        {
            _customer = customer;
        }

        [HttpGet]
        public ActionResult<List<Customer>> GetCustomers() {
            return Ok(_customer.GetCustomers());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Customer> GetCustomer(int id) {
            var customer = _customer.GetCustomer(id);

            if (customer != null) {
                return Ok(customer); 
            }
            
            return NotFound("No Matching Data Found");
        }

        [HttpPost]
        public IActionResult AddCustomer([FromBody] Customer customer)
        {
            var newCustomer = _customer.AddCustomer(customer);
            if (newCustomer.Id != null) {
                return Ok("Customer is added");
            }

            return NotFound("Failed to Add Data");
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateCustomer(int id,[FromBody] Customer customer)
        {
            var existingCustomer = _customer.GetCustomer(id);
            if (existingCustomer != null) {
                customer.Id = existingCustomer.Id;
                _customer.UpdateCustomer(customer);
                return Ok("Record is updated");
            }
            return NotFound("No Matching Data Found");
        }
    }
}
