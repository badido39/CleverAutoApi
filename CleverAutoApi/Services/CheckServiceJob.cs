using CleverAutoApi.Data;
using CleverAutoApi.Models;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CleverAutoApi.Services
{
    public class CheckServiceJob
    {
        private readonly MyDbContext _context;

        public CheckServiceJob(MyDbContext context)
        {
            _context = context;
        }

        public void CheckService()
        {
            var customers = _context.Customers.Include(c => c.Cars).ThenInclude(c => c.Services).ToList();
            foreach (var customer in customers)
            {
                foreach (var car in customer.Cars)
                {
                    foreach (var service in car.Services)
                    {
                        if (IsServiceDue(service, car) && service.ReminderSent == false)
                        {
                            SendServiceReminderSMS(customer, car.Services);
                            ReminderSent(customer, service);
                        }
                    }

                }

            }
        }
        private static bool IsServiceDue(Service service, Car car)
        {
            //calculate today mileage .......


            var CarAge = DateTime.Now.Year - car.YearOfFirstUse;


            //convert to days 

            var DaysFromLastService = DateTime.Now - service.DateOfService;

            Console.WriteLine(DaysFromLastService.Days);
            var AgeOfServiceInKM = service.EstimatedNextServiceMileage - service.MileageAtService;


            var estimatedKmWalkingToThisDay = DaysFromLastService.Days * (int)car.UseOfCarPerDay;
            Console.WriteLine(estimatedKmWalkingToThisDay);
            Console.WriteLine(AgeOfServiceInKM);
            // return car.CurrentMileage >= car.EstimatedNextServiceMileage;
            return estimatedKmWalkingToThisDay >= AgeOfServiceInKM;
        }

        private void ReminderSent(Customer customer, Service service)
        {

            //VERY IMPORTANT ---------- SEND SMS AND CHECK if SUCCES then set ReminderSent for the service to True, 
            service.ReminderSent = true;
            _context.Services.Update(service);
            _context.SaveChanges();
        }

       




        private static void SendServiceReminderSMS(Customer customer, List<Service> services)
        {
            // Implement your logic to send an SMS reminder to the customer

            Console.WriteLine($"*** == > Send Sms Reminder to {customer.Name} with those services :");
            foreach (var (service, index) in services.Select((value, i) => (value, i)))
            {
                Console.WriteLine($"     -{index + 1} : {service.Type} and your car mileage is : {service.MileageAtService} ");

            }
        }
    }
}
