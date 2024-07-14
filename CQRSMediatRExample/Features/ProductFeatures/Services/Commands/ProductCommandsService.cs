using MediatR;
using CQRSMediatRExample.Features.ProductFeatures.Commands.Create;
using CQRSMediatRExample.Features.ProductFeatures.Commands.Update;
using CQRSMediatRExample.Features.ProductFeatures.Commands.Delete;
using CQRSMediatRExample.Domain;

namespace CQRSMediatRExample.Features.ProductFeatures.Services.Commands;

public class ProductCommandsService(ISender mediatr) : IProductCommandsService
{
    public async Task<Product> CreateProduct(Product product)
        => await mediatr.Send(new CreateProductCommand(product));

    public async Task<Product> UpdateProduct(Guid id, Product product)
        => await mediatr.Send(new UpdateProductCommand(id, product));

    public async Task DeleteProduct(Guid id)
        => await mediatr.Send(new DeleteProductCommand(id));
}
