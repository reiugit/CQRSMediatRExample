using MediatR;

namespace CQRSMediatRExample.Behaviours;

public static class BehaviourExtensions
{
    public static void AddBehaviours(this IServiceCollection services)
    {
        services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(RequestLoggingBehaviour<,>));
        services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(ProductLoggingBehaviour<,>));
        services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(ProductListLoggingBehaviour<,>));
        services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(ProductDeleteLoggingBehaviour<,>));
    }
}