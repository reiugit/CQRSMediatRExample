using CQRSMediatRExample.Domain;

namespace CQRSMediatRExample.Features.ProductFeatures.Services.Commands;

public interface IProductCommandsService
{
    Task<Product> CreateProduct(Product product);
    Task<Product> UpdateProduct(Guid id, Product product);
    Task DeleteProduct(Guid id);
}