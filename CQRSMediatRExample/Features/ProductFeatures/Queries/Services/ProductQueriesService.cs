using MediatR;
using CQRSMediatRExample.Domain;
using CQRSMediatRExample.Features.ProductFeatures.Queries.Handlers.List;
using CQRSMediatRExample.Features.ProductFeatures.Queries.Handlers.Get;

namespace CQRSMediatRExample.Features.ProductFeatures.Queries.Services;

public class ProductQueriesService(ISender mediatr) : IProductQueriesService
{
    public async Task<List<Product>> ListProducts()
        => await mediatr.Send(new ListProductsQuery());

    public async Task<Product> GetProduct(Guid id)
        => await mediatr.Send(new GetProductQuery(id));
}
