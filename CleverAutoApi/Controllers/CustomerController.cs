using CleverAutoApi.Data;
using CleverAutoApi.DTOs;
using CleverAutoApi.Models;
using CleverAutoApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CleverAutoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService customerService;

        public CustomerController(CustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpPost]
        [Route("CreateCustomerWithCarAndService")]
        public IActionResult CreateCustomerWithCarAndService(Customer customer)
        {
            customerService.AddCustomer(customer);

            return Ok("Customer, Car, and Service added successfully.");
        }

        [HttpGet]
        [Route("GetAllCustomers")]
        public List<Customer> GetAllCustomers()
        {
            return customerService.GetAllCustomers();
        }


        [HttpGet]
        [Route("GetCustomerByName")]
        public Customer GetCustomerByName(string name)
        {
            return customerService.GetCustomerByName(name);
        }
        [HttpPost]
        [Route("UpdateCustomer")]
        public IActionResult UpdateCustomer(Customer customer)
        {
            customerService.UpdateCustomer(customer);

            return Ok("Customer, Updated");
        }
        [HttpDelete]
        [Route("DeleteCustomer")]
        public IActionResult DeleteCustomer(string name)
        {
            var customer = customerService.GetCustomerByName(name);
            if(customer == null)
            {
                return Ok("Customer not Found");
            }
            customerService.DeleteCustomer(customer);

            return Ok("Customer, Updated");
        }
        [HttpGet]
        [Route("ClearDatabase")]
        public IActionResult ClearDatabase()
        {
            customerService.ClearDatabase();
            return Ok("Database Cleared succufully !!!");
        }
    }
}
