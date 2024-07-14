using CQRSMediatRExample.Features.ProductFeatures.Queries.Dtos;
using CQRSMediatRExample.Features.ProductFeatures.Queries.Services;

namespace CQRSMediatRExample.Features.ProductFeatures.Queries.Endpoints;

public static class QueryEndpoints
{
    public static void MapProductQueryEndpoints(this WebApplication app)
    {
        app.MapGet("/products", async (IProductQueriesService productQueriesService) =>
        {
            var products = await productQueriesService.ListProducts();
            var productsDto = products.Select(p => ProductDto.FromProduct(p));

            return Results.Ok(productsDto);
        });

        app.MapGet("/products/{id:guid}", async (IProductQueriesService productQueriesService, Guid id) =>
        {
            var product = await productQueriesService.GetProduct(id);

            return product is null
                ? Results.NotFound()
                : Results.Ok(ProductDto.FromProduct(product));
        });
    }
}
