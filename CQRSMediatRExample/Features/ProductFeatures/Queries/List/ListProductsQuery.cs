using MediatR;
using CQRSMediatRExample.Features.ProductFeatures.Dtos;

namespace CQRSMediatRExample.Features.ProductFeatures.Queries.List;

public record ListProductsQuery : IRequest<List<ProductDto>>;
