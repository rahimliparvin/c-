using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Repository.Repositories.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=WIN-QHLO248GSCA\\SQLEXPRESS;Database=PB102LibraryDb;Trusted_Connection=True;");
        }
    }
}
