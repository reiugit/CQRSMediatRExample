using MediatR;
using CQRSMediatRExample.Features.ProductFeatures.Commands.Notifications.Contracts;

namespace CQRSMediatRExample.Features.ProductFeatures.Commands.Notifications.Handlers;

public class AlreadyDeletetedConsoleHandler : INotificationHandler<AlreadyDeletetedNotification>
{
    public Task Handle(AlreadyDeletetedNotification notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Console: Product '{notification.Id}' was already deleted\n");

        return Task.CompletedTask;
    }
}
