using MediatR;

namespace CQRSMediatRExample.Notifications;

public record AlreadyDeletetedNotification(string EntityTypeName) : INotification;
