using CQRSMediatRExample.Features.ProductFeatures.Dtos;
using CQRSMediatRExample.Features.ProductFeatures.Services.Commands;

namespace CQRSMediatRExample.Features.ProductFeatures.Endpoints;

public static class CommandEndpoints
{
    public static void MapProductCommandEndpoints(this WebApplication app)
    {
        app.MapPost("/products", async (IProductCommandsService productCommandsService, CreateProductDto createProductDto) =>
        {
            var product = await productCommandsService.CreateProduct(createProductDto.ToProduct());

            return product is null
                ? Results.BadRequest()
                : Results.Created($"/products/{product.Id}", ProductDto.FromProduct(product));
        });

        app.MapPut("/products/{id:guid}", async (IProductCommandsService productCommandsService, Guid id, UpdateProductDto updateProductDto) =>
        {
            var product = await productCommandsService.UpdateProduct(id, updateProductDto.ToProduct());

            return product is null
                ? Results.BadRequest()
                : Results.Created($"/products/{product.Id}", ProductDto.FromProduct(product));
        });

        app.MapDelete("/products/{id:guid}", async (IProductCommandsService productCommandsService, Guid id) =>
        {
            await productCommandsService.DeleteProduct(id);
            return Results.NoContent();
        });
    }
}
