using CQRSMediatRExample.Notifications;
using MediatR;

namespace CQRSMediatRExample.NotificationHandlers;

public class AlreadyDeletetedNotificationLoggingHandler(ILogger<AlreadyDeletetedNotificationLoggingHandler> logger)
    : INotificationHandler<AlreadyDeletetedNotification>
{
    public Task Handle(AlreadyDeletetedNotification notification, CancellationToken cancellationToken)
    {
        logger.LogWarning(">> {TypeName} was already deleted.\n", notification.EntityTypeName);

        return Task.CompletedTask;
    }
}
