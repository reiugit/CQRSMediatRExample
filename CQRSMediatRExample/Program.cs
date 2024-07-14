using Microsoft.EntityFrameworkCore;
using CQRSMediatRExample.Data;
using CQRSMediatRExample.Features.ProductFeatures.Endpoints;
using CQRSMediatRExample.Features.ProductFeatures.Services.Commands;
using CQRSMediatRExample.Features.ProductFeatures.Services.Queries;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDbContext<AppDbContext>(o => o.UseInMemoryDatabase("AppDb"));
    builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));
    
    builder.Services.AddScoped<IProductCommandsService, ProductCommandsService>();
    builder.Services.AddScoped<IProductQueriesService, ProductQueriesService>();
}

var app = builder.Build();
{
    app.MapProductQueryEndpoints();
    app.MapProductCommandEndpoints();
}

app.Run();
