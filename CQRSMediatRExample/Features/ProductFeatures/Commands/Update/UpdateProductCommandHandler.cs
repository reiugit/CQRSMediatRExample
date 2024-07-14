using MediatR;
using CQRSMediatRExample.Data;
using CQRSMediatRExample.Features.ProductFeatures.Dtos;

namespace CQRSMediatRExample.Features.ProductFeatures.Commands.Update;

public class UpdateProductCommandHandler(AppDbContext context) : IRequestHandler<UpdateProductCommand, ProductDto?>
{
    public async Task<ProductDto?> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await context.Products.FindAsync([command.Id], cancellationToken);

        if (product is null)
        {
            return null;
        }

        product.Name = command.UpdateProductDto.Name;

        context.Update(product);
        await context.SaveChangesAsync(cancellationToken);

        return ProductDto.FromProduct(product);
    }
}
