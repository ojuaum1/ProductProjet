using Microsoft.EntityFrameworkCore;
using ProductAPI.Domains;

namespace ProductAPI.Contexts
{
    public class Context : DbContext
    {
        public DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE02-SALA19; Database=ProductProject; User Id=sa; Password=Senai@134; TrustServerCertificate=True;");

        }
    }
}
