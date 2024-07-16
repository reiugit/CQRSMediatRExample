using CQRSMediatRExample.Notifications;
using MediatR;

namespace CQRSMediatRExample.NotificationHandlers;

public class AlreadyDeletetedConsoleHandler : INotificationHandler<AlreadyDeletetedNotification>
{
    public Task Handle(AlreadyDeletetedNotification notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Console: {notification.EntityTypeName} was already deleted\n");

        return Task.CompletedTask;
    }
}
