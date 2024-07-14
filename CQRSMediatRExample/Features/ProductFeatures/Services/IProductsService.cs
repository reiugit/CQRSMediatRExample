using CQRSMediatRExample.Domain;

namespace CQRSMediatRExample.Features.ProductFeatures.Services;

public interface IProductsService
{
    Task<List<Product>> ListProducts();
    Task<Product> GetProduct(Guid id);
    Task<Product> CreateProduct(Product product);
    Task<Product> UpdateProduct(Guid id, Product product);
    Task DeleteProduct(Guid id);
}