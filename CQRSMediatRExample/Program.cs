using Microsoft.EntityFrameworkCore;
using CQRSMediatRExample.Data;
using CQRSMediatRExample.Features.ProductFeatures.Services;
using CQRSMediatRExample.Features.ProductFeatures.Endpoints;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDbContext<AppDbContext>(o => o.UseInMemoryDatabase("AppDb"));
    builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));
    builder.Services.AddScoped<IProductsService, ProductsService>();
}

var app = builder.Build();
{
    app.MapProductQueryEndpoints();
    app.MapProductCommandEndpoints();
}

app.Run();
