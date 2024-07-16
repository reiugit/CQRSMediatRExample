using MediatR;

namespace CQRSMediatRExample.Features.ProductFeatures.Commands.Notifications.Contracts;

public record AlreadyDeletetedNotification(Guid Id) : INotification;
