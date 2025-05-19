using CQRSMediatr.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CQRSMediatr;

/// <summary>
/// Provides extension methods for registering CQRS Mediatr handlers and services.
/// </summary>
public static class RegisterCqrsMediatr
{
    /// <summary>
    /// Registers CQRS Mediatr services and all command/query handlers found in the assembly of the specified type.
    /// </summary>
    /// <param name="services">The service collection to add registrations to.</param>
    /// <param name="type">A type from the assembly to scan for handlers.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddCqrsMediatr(this IServiceCollection services, Type type)
    {
        var assembly = Assembly.GetAssembly(type);

        services.AddScoped<ICqrsMediatr, CqrsMediatr>();

        var queryHandlers = assembly.GetTypes()
            .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IQueryHandler<,>)))
            .ToList();

        foreach (var handler in queryHandlers)
        {
            var interfaceType = handler.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(IQueryHandler<,>));
            services.AddScoped(interfaceType, handler);
        }

        var commandHandlers = assembly.GetTypes()
            .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<,>)))
            .ToList();

        foreach (var handler in commandHandlers)
        {
            var interfaceType = handler.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(ICommandHandler<,>));
            services.AddScoped(interfaceType, handler);
        }

        return services;
    }
}
