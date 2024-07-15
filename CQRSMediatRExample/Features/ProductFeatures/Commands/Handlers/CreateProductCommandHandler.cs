using MediatR;
using CQRSMediatRExample.Data;
using CQRSMediatRExample.Domain;

namespace CQRSMediatRExample.Features.ProductFeatures.Commands.Handlers;

public record CreateProductCommand(Product Product) : IRequest<Product>;

public class CreateProductCommandHandler(AppDbContext context) : IRequestHandler<CreateProductCommand, Product>
{
    public async Task<Product> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = command.Product;

        context.Add(product);
        await context.SaveChangesAsync(cancellationToken);

        return product;
    }
}
