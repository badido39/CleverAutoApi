using CleverAutoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CleverAutoApi.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        // Add DbSet properties for your entities
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}