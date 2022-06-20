using Microsoft.EntityFrameworkCore;
using ShopBridgeDAL.Models;

namespace ShopBridge.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ProductTypeDALmodel> ProductTypes { get; set; }
        public DbSet<ProductCategoryDALModel> ProductCategories { get; set; }
        public DbSet<ProductDALModel> Products { get; set; }

    }
}
