using MediatR;
using CQRSMediatRExample.Domain;
using CQRSMediatRExample.Features.ProductFeatures.Commands.Handlers;

namespace CQRSMediatRExample.Features.ProductFeatures.Commands.Services;

public class ProductCommandsService(ISender mediatr) : IProductCommandsService
{
    public async Task<Product> CreateProduct(Product product)
        => await mediatr.Send(new CreateProductCommand(product));

    public async Task<Product> UpdateProduct(Guid id, Product product)
        => await mediatr.Send(new UpdateProductCommand(id, product));

    public async Task DeleteProduct(Guid id)
        => await mediatr.Send(new DeleteProductCommand(id));
}
