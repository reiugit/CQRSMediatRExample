using MediatR;
using CQRSMediatRExample.Data;

namespace CQRSMediatRExample.Features.ProductFeatures.Commands.Handlers;

public record DeleteProductCommand(Guid Id) : IRequest;

public class DeleteProductCommandHandler(AppDbContext context) : IRequestHandler<DeleteProductCommand>
{
    public async Task Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var product = await context.Products.FindAsync([command.Id], cancellationToken);

        if (product == null)
        {
            return;
        }

        context.Products.Remove(product);
        await context.SaveChangesAsync(cancellationToken);
    }
}
