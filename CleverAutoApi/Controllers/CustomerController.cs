using CleverAutoApi.Data;
using CleverAutoApi.DTOs;
using CleverAutoApi.Models;
using CleverAutoApi.Services;
using CleverAutoApi.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace CleverAutoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService customerService;
        private readonly IHubContext<NotificationHub> _hubContext;


        public CustomerController(CustomerService customerService, IHubContext<NotificationHub> hubContext)
        {
            this.customerService = customerService;
            _hubContext = hubContext;
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
            _hubContext.Clients.All.SendAsync("ReceiveMessage", "User Added Succufully");
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
