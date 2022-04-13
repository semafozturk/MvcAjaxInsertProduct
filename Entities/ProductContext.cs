using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ProductContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ProductContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer(Configuration.GetConnectionString("UserDBEntities"));
            options.UseSqlServer("Data Source=DESKTOP-B5K4J84\\SEM;Initial Catalog=Products;Integrated Security=True", option => {
                option.EnableRetryOnFailure();
            });
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Category>().ToTable("Category");
            /* modelBuilder.Entity<Product>()
                                 .HasMany(c => c.Category)
                                 .WithOne(e => e.Product);
            */

        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
