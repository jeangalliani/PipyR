using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PipyR.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPipyR(this IServiceCollection services, Assembly assembly)
        {
            services.AddSingleton(typeof(PipyR));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            AssemblyScanner.FindValidatorsInAssembly(assembly).ForEach(result =>
                services.AddScoped(result.InterfaceType, result.ValidatorType)
            );

            return services
                .AddMediatR(assembly)
                    .AddAutoMapper(assembly);
        }
    }
}