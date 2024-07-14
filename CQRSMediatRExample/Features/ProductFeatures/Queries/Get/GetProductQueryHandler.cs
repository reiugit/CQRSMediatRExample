using MediatR;
using CQRSMediatRExample.Data;
using CQRSMediatRExample.Features.ProductFeatures.Dtos;

namespace CQRSMediatRExample.Features.ProductFeatures.Queries.Get;

public class GetProductQueryHandler(AppDbContext context) : IRequestHandler<GetProductQuery, ProductDto?>
{
    public async Task<ProductDto?> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await context.Products
            .FindAsync([request.Id], cancellationToken);

        if (product is null)
        {
            return null;
        }

        return ProductDto.FromProduct(product);
    }
}
