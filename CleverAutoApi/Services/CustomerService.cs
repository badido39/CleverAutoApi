using CleverAutoApi.Data;
using CleverAutoApi.Models;

namespace CleverAutoApi.Services
{
    public class CustomerService
    {
        private readonly MyDbContext _dbContext;

        public CustomerService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Add a new customer
        public void AddCustomer(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
        }

        // Get a list of all customers
        public List<Customer> GetAllCustomers()
        {
            return _dbContext.Customers.ToList();
        }

        // Get a customer by their name
        public Customer GetCustomerByName(string name)
        {
            return _dbContext.Customers.FirstOrDefault(c => c.Name == name);
        }

        // Update an existing customer
        public void UpdateCustomer(Customer customer)
        {
            _dbContext.Customers.Update(customer);
            _dbContext.SaveChanges();
        }

        // Delete a customer
        public void DeleteCustomer(Customer customer)
        {
            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();
        }
    }
}

