using CQRSMediatRExample.Domain;

namespace CQRSMediatRExample.Features.ProductFeatures.Services.Queries;

public interface IProductQueriesService
{
    Task<List<Product>> ListProducts();
    Task<Product> GetProduct(Guid id);
}