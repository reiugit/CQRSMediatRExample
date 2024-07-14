using MediatR;
using CQRSMediatRExample.Features.ProductFeatures.Queries.List;
using CQRSMediatRExample.Features.ProductFeatures.Queries.Get;
using CQRSMediatRExample.Domain;

namespace CQRSMediatRExample.Features.ProductFeatures.Services.Queries;

public class ProductQueriesService(ISender mediatr) : IProductQueriesService
{
    public async Task<List<Product>> ListProducts()
        => await mediatr.Send(new ListProductsQuery());

    public async Task<Product> GetProduct(Guid id)
        => await mediatr.Send(new GetProductQuery(id));
}
