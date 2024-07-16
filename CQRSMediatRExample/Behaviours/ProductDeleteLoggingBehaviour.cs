using MediatR;
using CQRSMediatRExample.Features.ProductFeatures.Commands.Handlers;

namespace CQRSMediatRExample.Behaviours;

public class ProductDeleteLoggingBehaviour<TRequest, TResponse>(ILogger<ProductDeleteLoggingBehaviour<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : DeleteProductCommand
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        logger.LogWarning(">> Product '{ProductId}' is requested to be deleted.\n", request.Id);

        return await next();
    }
}
