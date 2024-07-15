using Microsoft.EntityFrameworkCore;
using CQRSMediatRExample.Data;
using CQRSMediatRExample.Features.ProductFeatures.Queries.Endpoints;
using CQRSMediatRExample.Features.ProductFeatures.Queries.Services;
using CQRSMediatRExample.Features.ProductFeatures.Commands.Endpoints;
using CQRSMediatRExample.Features.ProductFeatures.Commands.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDbContext<AppDbContext>(o => o.UseInMemoryDatabase("AppDb"));
    builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<Program>());
    
    builder.Services.AddScoped<IProductQueriesService, ProductQueriesService>();
    builder.Services.AddScoped<IProductCommandsService, ProductCommandsService>();
}

var app = builder.Build();
{
    app.MapProductQueryEndpoints();
    app.MapProductCommandEndpoints();
}

app.Run();
