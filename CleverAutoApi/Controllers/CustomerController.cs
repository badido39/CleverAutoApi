using CleverAutoApi.Data;
using CleverAutoApi.DTOs;
using CleverAutoApi.Models;
using CleverAutoApi.Services;
using CleverAutoApi.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalRWebApi.Services;
using System.Diagnostics;

namespace CleverAutoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService customerService;

        private readonly INotificationService _notificationService;


        public CustomerController(CustomerService customerService, INotificationService notificationService)
        {
            this.customerService = customerService;
            _notificationService = notificationService;
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
            Notification notification = new Notification { Created = DateTime.UtcNow, Message = "Hello World kjh;dkijhb;dkijb;kjbd", Title = "Wather ForCast" };
            Debug.WriteLine(notification.Message);
            _notificationService.SendNotification(notification);
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
