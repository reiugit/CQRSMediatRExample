using MediatR;

namespace CQRSMediatRExample.Behaviours;

public class LoggingBehaviour<TRequest, TResponse>(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("  1.) Before handling '{Request}'", typeof(TRequest).Name);

        var response = await next();

        logger.LogInformation("  2.) After having handled '{Request}'", typeof(TRequest).Name);

        return response;
    }
}
