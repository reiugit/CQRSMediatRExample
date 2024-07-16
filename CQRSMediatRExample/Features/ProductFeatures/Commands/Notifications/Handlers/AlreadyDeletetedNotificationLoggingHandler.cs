using MediatR;
using CQRSMediatRExample.Features.ProductFeatures.Commands.Notifications.Contracts;

namespace CQRSMediatRExample.Features.ProductFeatures.Commands.Notifications.Handlers;

public class AlreadyDeletetedNotificationLoggingHandler(ILogger<AlreadyDeletetedNotificationLoggingHandler> logger)
    : INotificationHandler<AlreadyDeletetedNotification>
{
    public Task Handle(AlreadyDeletetedNotification notification, CancellationToken cancellationToken)
    {
        logger.LogWarning(">> Product '{ProduktId}' was already deleted.\n", notification.Id);

        return Task.CompletedTask;
    }
}
