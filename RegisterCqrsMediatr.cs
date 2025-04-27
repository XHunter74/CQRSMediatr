using CQRSMediatr;
using CQRSMediatr.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MultiTenantDbContext.CQRS;

public static class RegisterCqrsMediatr
{
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
