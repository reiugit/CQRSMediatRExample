using MediatR;
using CQRSMediatRExample.Domain;

namespace CQRSMediatRExample.Features.ProductFeatures.Queries.Handlers.List;

public record ListProductsQuery : IRequest<List<Product>>;
