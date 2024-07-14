using MediatR;
using CQRSMediatRExample.Domain;

namespace CQRSMediatRExample.Features.ProductFeatures.Commands.Create;

public record CreateProductCommand(Product Product) : IRequest<Product>;
