using Microsoft.EntityFrameworkCore;
using ProductCore.Models;

namespace ProductWebAPI.Models
{
    public class ProductAppContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public ProductAppContext(DbContextOptions<ProductAppContext> options) : base(options)
        {

        }
    }
}
