using CleverAutoApi.Data;
using CleverAutoApi.Models;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CleverAutoApi.Services
{
    public  class CheckServiceJob
    {
        private readonly MyDbContext _context;

        public CheckServiceJob(MyDbContext context)
        {
            _context = context;
        }

        public void CheckService()
        {
            var customers = _context.Customers.Include(c => c.Cars).ToList();
            foreach (var customer in customers)
            {
                foreach (var car in customer.Cars)
                {
                    if (IsServiceDue(car))
                    {
                        SendServiceReminderSMS(customer, car);
                    }
                }
            }
        }

        private static bool IsServiceDue(Car car)
        {
            // Implement your logic to check if the car is due for service
            return car.CurrentMileage >= car.EstimatedNextServiceMileage;
        }

        private static void SendServiceReminderSMS(Customer customer, Car car)
        {
            // Implement your logic to send an SMS reminder to the customer
        }
    }
}
