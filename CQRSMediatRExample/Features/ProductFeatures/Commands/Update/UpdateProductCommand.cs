using MediatR;
using CQRSMediatRExample.Domain;

namespace CQRSMediatRExample.Features.ProductFeatures.Commands.Update;

public record UpdateProductCommand(Guid Id, Product Product) : IRequest<Product>;
