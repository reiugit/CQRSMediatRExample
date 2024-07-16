using MediatR;

namespace CQRSMediatRExample.Notifications.Contracts;

public record AlreadyDeletetedNotification(string EntityTypeName) : INotification;
