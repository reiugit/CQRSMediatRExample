using MediatR;
using CQRSMediatRExample.Domain;

namespace CQRSMediatRExample.Features.ProductFeatures.Queries.Handlers.Get;

public record GetProductQuery(Guid Id) : IRequest<Product>;
