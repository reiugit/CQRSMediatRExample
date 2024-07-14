using Microsoft.EntityFrameworkCore;
using CQRSMediatRExample.Features.ProductFeatures.Dtos;
using CQRSMediatRExample.Data;
using CQRSMediatRExample.Features.ProductFeatures.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDbContext<AppDbContext>(o => o.UseInMemoryDatabase("AppDb"));
    builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));
    builder.Services.AddScoped<IProductsService, ProductsService>();
}

var app = builder.Build();

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

app.Run();
