﻿using MediatR;
using CQRSMediatRExample.Data;
using CQRSMediatRExample.Features.ProductFeatures.Commands.Notifications.Contracts;

namespace CQRSMediatRExample.Features.ProductFeatures.Commands.Handlers;

public record DeleteProductCommand(Guid Id) : IRequest;

public class DeleteProductCommandHandler(AppDbContext context, IPublisher mediatr) : IRequestHandler<DeleteProductCommand>
{
    public async Task Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var product = await context.Products.FindAsync([command.Id], cancellationToken);

        if (product == null)
        {
            await mediatr.Publish(new AlreadyDeletetedNotification(command.Id), cancellationToken);
            return;
        }

        context.Products.Remove(product);
        await context.SaveChangesAsync(cancellationToken);
    }
}
