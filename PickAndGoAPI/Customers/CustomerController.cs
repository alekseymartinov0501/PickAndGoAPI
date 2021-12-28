using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickAndGoAPI.Customers.AppService;
using PickAndGoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.Customers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly CustomerMasterAppService _customerMasterAppService;

        public CustomerController(CustomerMasterAppService customerMasterAppService)
        {
            _customerMasterAppService = customerMasterAppService;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var response = await _customerMasterAppService.GetCustomers();
            return response;
        }

        [HttpGet("{id}")]
        public async Task<Customer> GetCustomer(int id)
        {
            var res = await _customerMasterAppService.GetCustomer(id);
            return res;
        }

        [HttpPost]

        public ActionResult<Customer> GetCustomer(Customer customer)
        {
            _customerMasterAppService.AddCustomer(customer);
            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }
    }
}
