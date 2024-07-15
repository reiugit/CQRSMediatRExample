using CQRSMediatRExample.Features.ProductFeatures.Commands.Dtos;
using CQRSMediatRExample.Features.ProductFeatures.Commands.Handlers;
using MediatR;

namespace CQRSMediatRExample.Features.ProductFeatures.Commands.Endpoints;

public static class CommandEndpoints
{
    public static void MapProductCommandEndpoints(this WebApplication app)
    {
        app.MapPost("/products", async (ISender mediatr, CreateProductDto createProductDto) =>
        {
            var product = await mediatr.Send(new CreateProductCommand(createProductDto.ToProduct()));

            return product is null
                ? Results.BadRequest()
                : Results.Created($"/products/{product.Id}", ProductDto.FromProduct(product));
        });

        app.MapPut("/products/{id:guid}", async (ISender mediatr, Guid id, UpdateProductDto updateProductDto) =>
        {
            var product = await mediatr.Send(new UpdateProductCommand(id, updateProductDto.ToProduct()));

            return product is null
                ? Results.BadRequest()
                : Results.Created($"/products/{product.Id}", ProductDto.FromProduct(product));
        });

        app.MapDelete("/products/{id:guid}", async (ISender mediatr, Guid id) =>
        {
            await mediatr.Send(new DeleteProductCommand(id));
            return Results.NoContent();
        });
    }
}
