using MediatR;

namespace CQRSMediatRExample.Features.ProductFeatures.Commands.Delete;

public record DeleteProductCommand(Guid Id) : IRequest;
