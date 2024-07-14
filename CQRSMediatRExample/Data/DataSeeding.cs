using Microsoft.EntityFrameworkCore;
using CQRSMediatRExample.Domain;

namespace CQRSMediatRExample.Data;

public static class DataSeeding
{
    public static void SeedData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData([
            new Product { Id = Guid.NewGuid(), Name = "Product 1" },
            new Product { Id = Guid.NewGuid(), Name = "Product 2" }]);
    }
}
