using Microsoft.EntityFrameworkCore;
using MediatR;
using CQRSMediatRExample.Data;
using CQRSMediatRExample.Domain;

namespace CQRSMediatRExample.Features.ProductFeatures.Queries.List;

public class ListProductsQueryHandler(AppDbContext context) : IRequestHandler<ListProductsQuery, List<Product>>
{
    public async Task<List<Product>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
    {
        return await context.Products.ToListAsync(cancellationToken);
    }
}
