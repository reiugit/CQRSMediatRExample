using CQRSMediatRExample.Features.ProductFeatures.Dtos;
using CQRSMediatRExample.Features.ProductFeatures.Services;

namespace CQRSMediatRExample.Features.ProductFeatures.Endpoints;

public static class QueryEndpoints
{
    public static void MapProductQueryEndpoints(this WebApplication app)
    {
        app.MapGet("/products", async (IProductsService productsService) =>
        {
            var products = await productsService.ListProducts();
            var productsDto = products.Select(p => ProductDto.FromProduct(p));

            return Results.Ok(productsDto);
        });

        app.MapGet("/products/{id:guid}", async (IProductsService productsService, Guid id) =>
        {
            var product = await productsService.GetProduct(id);

            return product is null
                ? Results.NotFound()
                : Results.Ok(ProductDto.FromProduct(product));
        });
    }
}
