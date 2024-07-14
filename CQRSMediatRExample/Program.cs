using Microsoft.EntityFrameworkCore;
using MediatR;
using CQRSMediatRExample.Features.ProductFeatures.Queries.List;
using CQRSMediatRExample.Features.ProductFeatures.Queries.Get;
using CQRSMediatRExample.Features.ProductFeatures.Commands.Create;
using CQRSMediatRExample.Features.ProductFeatures.Commands.Update;
using CQRSMediatRExample.Features.ProductFeatures.Commands.Delete;
using CQRSMediatRExample.Features.ProductFeatures.Dtos;
using CQRSMediatRExample.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(o => o.UseInMemoryDatabase("AppDb"));
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();

app.MapGet("/products", async (ISender mediatr) =>
{
    var productDtos = await mediatr.Send(new ListProductsQuery());

    return Results.Ok(productDtos);
});

app.MapGet("/products/{id:guid}", async (ISender mediatr, Guid id) =>
{
    var productDto = await mediatr.Send(new GetProductQuery(id));

    return productDto is null
        ? Results.NotFound()
        : Results.Ok(productDto);
});

app.MapPost("/products", async (ISender mediatr, CreateProductDto createProductDto) =>
{
    var productDto = await mediatr.Send(new CreateProductCommand(createProductDto));

    return productDto is null
        ? Results.BadRequest()
        : Results.Created($"/products/{productDto.Id}", productDto);
});

app.MapPut("/products/{id:guid}", async (ISender mediatr, Guid id, UpdateProductDto updateProductDto) =>
{
    var result = await mediatr.Send(new UpdateProductCommand(id, updateProductDto));

    return result is null
        ? Results.BadRequest()
        : Results.Ok(result);
});

app.MapDelete("/products/{id:guid}", async (ISender mediatr, Guid id) =>
{
    await mediatr.Send(new DeleteProductCommand(id));

    return Results.NoContent();
});

app.Run();
