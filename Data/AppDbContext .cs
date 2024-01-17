using LuminariasWeb.sln.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuración de la entidad Product
        modelBuilder.Entity<Product>().ToTable("Products");
        modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired();
        modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<Product>().HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);

        // Configuración de la entidad Category
        modelBuilder.Entity<Category>().ToTable("Categories");
        modelBuilder.Entity<Category>().Property(c => c.CategoryName).IsRequired();

        // Configuración de la entidad Service
        modelBuilder.Entity<Service>().ToTable("Servicios");
        modelBuilder.Entity<Service>().Property(s => s.Name).IsRequired();
        modelBuilder.Entity<Service>().Property(s => s.Price).HasColumnType("decimal(18,2)");

        // Configuración de la entidad User
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<User>().Property(u => u.Name).IsRequired();
        modelBuilder.Entity<User>().Property(u => u.Password).IsRequired();
    }
}