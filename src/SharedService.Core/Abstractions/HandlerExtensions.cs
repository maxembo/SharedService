using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace SharedService.Core.Abstractions;

public static class HandlerExtensions
{
    public static IServiceCollection AddCommands(this IServiceCollection services, Assembly assemblies)
        => services.Scan(
            scan => scan
                .FromAssemblies(assemblies)
                .AddClasses(
                    classes =>
                        classes.AssignableToAny(typeof(ICommandHandler<,>), typeof(ICommandHandler<>)))
                .AsSelfWithInterfaces()
                .WithScopedLifetime());

    public static IServiceCollection AddQueries(this IServiceCollection services, Assembly assemblies)
        => services.Scan(
            scan => scan
                .FromAssemblies(assemblies)
                .AddClasses(
                    classes =>
                        classes.AssignableToAny(typeof(IQueryHandler<,>), typeof(IQueryHandler<>)))
                .AsSelfWithInterfaces()
                .WithScopedLifetime());
}