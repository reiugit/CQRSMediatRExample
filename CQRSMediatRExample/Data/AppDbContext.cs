using Microsoft.EntityFrameworkCore;
using CQRSMediatRExample.Domain;

namespace CQRSMediatRExample.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Product> Products { get; set; } = default!;

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.SeedData();
    }
}