using Microsoft.EntityFrameworkCore;
using MediatR;
using CQRSMediatRExample.Data;
using CQRSMediatRExample.Behaviours;
using CQRSMediatRExample.Features.ProductFeatures.Queries.Endpoints;
using CQRSMediatRExample.Features.ProductFeatures.Commands.Endpoints;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDbContext<AppDbContext>(o => o.UseInMemoryDatabase("AppDb"));
    builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<Program>());
    builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(RequestLoggingBehaviour<,>));
    builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(ProductLoggingBehaviour<,>));
    builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(ProductListLoggingBehaviour<,>));
}

var app = builder.Build();
{
    app.MapProductQueryEndpoints();
    app.MapProductCommandEndpoints();
}

app.Run();
