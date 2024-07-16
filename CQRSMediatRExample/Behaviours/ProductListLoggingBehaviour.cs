using CQRSMediatRExample.Domain;
using MediatR;

namespace CQRSMediatRExample.Behaviours;

public class ProductListLoggingBehaviour<TRequest, TResponse>(ILogger<RequestLoggingBehaviour<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : List<Product>
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var products = await next();

        logger.LogInformation(
            ">> {ProductCount} products were listed.\n",
            products.Count);

        return products;
    }
}
