using MediatR;

namespace CQRSMediatRExample.Features.ProductFeatures.Commands.Handlers.Delete;

public record DeleteProductCommand(Guid Id) : IRequest;
