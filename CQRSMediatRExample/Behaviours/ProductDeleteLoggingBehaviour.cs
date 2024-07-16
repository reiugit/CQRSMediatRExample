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
        logger.LogWarning(">> Product with ID '{ProductId}' is going to be deleted.\n", request.Id);

        var response = await next();

        return response;
    }
}
