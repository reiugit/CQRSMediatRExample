using MediatR;

namespace CQRSMediatRExample.Behaviours;

public class RequestLoggingBehaviour<TRequest, TResponse>(ILogger<RequestLoggingBehaviour<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    //where TResponse : Product
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var response = await next();

        logger.LogInformation(">> '{Request}' was handled.", typeof(TRequest).Name);

        return response;
    }
}
