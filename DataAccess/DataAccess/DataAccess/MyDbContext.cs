using System.Data.Entity;

namespace DataAccess
{
    public class MyDBContext: DbContext
    {
         
        public DbSet<Customer> Customers { get; set; }
    }
}