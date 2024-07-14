using MediatR;
using CQRSMediatRExample.Features.ProductFeatures.Queries.List;
using CQRSMediatRExample.Features.ProductFeatures.Queries.Get;
using CQRSMediatRExample.Features.ProductFeatures.Commands.Create;
using CQRSMediatRExample.Features.ProductFeatures.Commands.Update;
using CQRSMediatRExample.Features.ProductFeatures.Commands.Delete;
using CQRSMediatRExample.Domain;

namespace CQRSMediatRExample.Features.ProductFeatures.Services;

public class ProductsService(ISender mediatr) : IProductsService
{
    public async Task<List<Product>> ListProducts()
        => await mediatr.Send(new ListProductsQuery());

    public async Task<Product> GetProduct(Guid id)
        => await mediatr.Send(new GetProductQuery(id));

    public async Task<Product> CreateProduct(Product product)
        => await mediatr.Send(new CreateProductCommand(product));

    public async Task<Product> UpdateProduct(Guid id, Product product)
        => await mediatr.Send(new UpdateProductCommand(id, product));

    public async Task DeleteProduct(Guid id)
        => await mediatr.Send(new DeleteProductCommand(id));
}
