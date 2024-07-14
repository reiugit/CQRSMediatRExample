using MediatR;
using CQRSMediatRExample.Features.ProductFeatures.Dtos;

namespace CQRSMediatRExample.Features.ProductFeatures.Queries.Get;

public record GetProductQuery(Guid Id) : IRequest<ProductDto>;
