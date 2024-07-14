using MediatR;
using CQRSMediatRExample.Domain;

namespace CQRSMediatRExample.Features.ProductFeatures.Queries.List;

public record ListProductsQuery : IRequest<List<Product>>;
