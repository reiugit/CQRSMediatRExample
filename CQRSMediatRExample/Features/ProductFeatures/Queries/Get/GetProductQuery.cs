using MediatR;
using CQRSMediatRExample.Domain;

namespace CQRSMediatRExample.Features.ProductFeatures.Queries.Get;

public record GetProductQuery(Guid Id) : IRequest<Product>;
