﻿using MediatR;
using CQRSMediatRExample.Data;
using CQRSMediatRExample.Domain;

namespace CQRSMediatRExample.Features.ProductFeatures.Queries.Get;

public class GetProductQueryHandler(AppDbContext context) : IRequestHandler<GetProductQuery, Product?>
{
    public async Task<Product?> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        return await context.Products
                            .FindAsync([request.Id], cancellationToken);
    }
}
