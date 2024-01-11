using LuminariasWeb.sln.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<Product> Products { get; set; }  
    public DbSet<Service> Services { get; set; }
    public DbSet<User> Users { get; set; }
}