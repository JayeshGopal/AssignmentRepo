using Microsoft.EntityFrameworkCore;


namespace WebApp.Models
{
    public class CustomerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public CustomerContext(DbContextOptions<CustomerContext> options):base(options)
        {
        }
    }
}
