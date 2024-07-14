using MediatR;
using CQRSMediatRExample.Data;
using CQRSMediatRExample.Domain;

namespace CQRSMediatRExample.Features.ProductFeatures.Commands.Handlers.Update;

public class UpdateProductCommandHandler(AppDbContext context) : IRequestHandler<UpdateProductCommand, Product?>
{
    public async Task<Product?> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await context.Products.FindAsync([command.Id], cancellationToken);

        if (product is null)
        {
            return null;
        }

        product.Name = command.Product.Name;

        context.Update(product);
        await context.SaveChangesAsync(cancellationToken);

        return product;
    }
}
