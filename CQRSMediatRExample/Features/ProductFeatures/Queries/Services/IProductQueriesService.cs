using CQRSMediatRExample.Domain;

namespace CQRSMediatRExample.Features.ProductFeatures.Queries.Services;

public interface IProductQueriesService
{
    Task<List<Product>> ListProducts();
    Task<Product> GetProduct(Guid id);
}