using MediatR;
using CQRSMediatRExample.Domain;

namespace CQRSMediatRExample.Features.ProductFeatures.Commands.Handlers.Create;

public record CreateProductCommand(Product Product) : IRequest<Product>;
