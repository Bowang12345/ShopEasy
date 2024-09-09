using Microsoft.EntityFrameworkCore;
using ShopEzy.Models;

namespace ShopEzy.Data
{
    public class ShopEzyDbContext: DbContext
    {
        public ShopEzyDbContext(DbContextOptions<ShopEzyDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

    
    }
}
