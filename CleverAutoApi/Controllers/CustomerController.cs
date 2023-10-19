using CleverAutoApi.Data;
using CleverAutoApi.DTOs;
using CleverAutoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleverAutoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CustomerController(MyDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("CreateCustomerWithCarAndService")]
        public IActionResult CreateCustomerWithCarAndService(CustomerCarServiceDTO DTO)
        {
            _context.Customers.Add(DTO.Customer);
            _context.SaveChanges();

            DTO.Car.CustomerId = DTO.Customer.Id; // Assuming the Car model has a Customer property
            _context.Cars.Add(DTO.Car);
            _context.SaveChanges();

            DTO.Service.CarId = DTO.Car.Id; // Assuming the Service model has a Car property
            _context.Services.Add(DTO.Service);
            _context.SaveChanges();

            return Ok("Customer, Car, and Service added successfully.");
        }
    }
}
