﻿using AspNetCoreBlog.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreBlog.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB; Database=AspNetCoreBlog; integrated security=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Email = "admin@aspnetcoreblog.net",
                IsActive = true,
                IsAdmin = true,
                Name = "Admin",
                Surname = "User",
                Username = "Admin",
                Password = "123456"
            });
            base.OnModelCreating(modelBuilder);
        }
        // Yukarıdaki ayarları yapılandırdıktan sonra program.cs ye DatabaseContext i servis olarak ekliyoruz.

        // Sonraki aşamada Package manager console dan migration oluşturup update-database komutuyla veritabanını oluşturuyoruz

    }
}
