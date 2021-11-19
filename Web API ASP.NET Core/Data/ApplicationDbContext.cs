using Microsoft.EntityFrameworkCore;
using Web_API_ASP.NET_Core.Model;

namespace Web_API_ASP.NET_Core.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Fornecedor> Fornecedor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=WebApiAspNetCoreDatabase;User ID=postgres;Password=123456;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
