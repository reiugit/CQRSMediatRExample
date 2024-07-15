using CQRSMediatRExample.Features.ProductFeatures.Queries.Dtos;
using CQRSMediatRExample.Features.ProductFeatures.Queries.Handlers;
using MediatR;

namespace CQRSMediatRExample.Features.ProductFeatures.Queries.Endpoints;

public static class QueryEndpoints
{
    public static void MapProductQueryEndpoints(this WebApplication app)
    {
        app.MapGet("/products", async (ISender mediatr) =>
        {
            var products = await mediatr.Send(new ListProductsQuery());
            var productsDto = products.Select(p => ProductDto.FromProduct(p));

            return Results.Ok(productsDto);
        });

        app.MapGet("/products/{id:guid}", async (ISender mediatr, Guid id) =>
        {
            var product = await mediatr.Send(new GetProductQuery(id));

            return product is null
                ? Results.NotFound()
                : Results.Ok(ProductDto.FromProduct(product));
        });
    }
}
