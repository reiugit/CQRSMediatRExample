using MediatR;

namespace CQRSMediatRExample.Notifications;

public record EntityWasAlreadyDeletetedNotification(string EntityTypeName) : INotification;

public class EntityWasAlreadyDeletetedNotificationHandler(ILogger<EntityWasAlreadyDeletetedNotificationHandler> logger)
    : INotificationHandler<EntityWasAlreadyDeletetedNotification>
{
    public Task Handle(EntityWasAlreadyDeletetedNotification notification, CancellationToken cancellationToken)
    {
        logger.LogWarning("{TypeName} was already deleted.", notification.EntityTypeName);

        return Task.CompletedTask;
    }
}
