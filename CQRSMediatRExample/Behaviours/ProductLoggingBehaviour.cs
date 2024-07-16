using CQRSMediatRExample.Domain;
using MediatR;

namespace CQRSMediatRExample.Behaviours;

public class ProductLoggingBehaviour<TRequest, TResponse>(ILogger<RequestLoggingBehaviour<TRequest, TResponse?>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Product
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var product = await next();

        if (product is null)
        {
            logger.LogWarning(">> Product was not found.\n");
        }
        else
        {
            logger.LogInformation(">> Product '{ProductName}' was handled.\n", product.Name);
        }

        return product!;
    }
}
