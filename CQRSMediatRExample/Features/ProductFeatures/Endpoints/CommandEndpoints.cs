using CQRSMediatRExample.Features.ProductFeatures.Dtos;
using CQRSMediatRExample.Features.ProductFeatures.Services;

namespace CQRSMediatRExample.Features.ProductFeatures.Endpoints;

public static class CommandEndpoints
{
    public static void MapProductCommandEndpoints(this WebApplication app)
    {
        app.MapPost("/products", async (IProductsService productsService, CreateProductDto createProductDto) =>
        {
            var product = await productsService.CreateProduct(createProductDto.ToProduct());

            return product is null
                ? Results.BadRequest()
                : Results.Created($"/products/{product.Id}", ProductDto.FromProduct(product));
        });

        app.MapPut("/products/{id:guid}", async (IProductsService productsService, Guid id, UpdateProductDto updateProductDto) =>
        {
            var product = await productsService.UpdateProduct(id, updateProductDto.ToProduct());

            return product is null
                ? Results.BadRequest()
                : Results.Created($"/products/{product.Id}", ProductDto.FromProduct(product));
        });

        app.MapDelete("/products/{id:guid}", async (IProductsService productsService, Guid id) =>
        {
            await productsService.DeleteProduct(id);
            return Results.NoContent();
        });
    }
}
