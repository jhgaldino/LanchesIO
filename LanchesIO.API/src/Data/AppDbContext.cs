using Microsoft.EntityFrameworkCore;
using LanchesIO.API.src.Models;

namespace LanchesIO.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; } // Adicione o DbSet para UserLogin

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definir a chave primária para UserLogin
            modelBuilder.Entity<UserLogin>()
                .HasKey(ul => ul.Id);
        }
    }
}
