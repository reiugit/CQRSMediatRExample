using Microsoft.EntityFrameworkCore;
using MediatR;
using CQRSMediatRExample.Data;
using CQRSMediatRExample.Features.ProductFeatures.Dtos;

namespace CQRSMediatRExample.Features.ProductFeatures.Queries.List;

public class ListProductsQueryHandler(AppDbContext context) : IRequestHandler<ListProductsQuery, List<ProductDto>>
{
    public async Task<List<ProductDto>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
    {
        return await context.Products
            .Select(p => ProductDto.FromProduct(p))
            .ToListAsync(cancellationToken);
    }
}
