using CQRSMediatr.Interfaces;
using CQRSMediatr.TestApp.Features;
using Microsoft.Extensions.DependencyInjection;
using MultiTenantDbContext.CQRS;

namespace CQRSMediatr.TestApp;

public class Program
{
    public static async Task Main(string[] args)
    {
        // Setup DI
        var services = new ServiceCollection();
        services.AddCqrsMediatr(typeof(Program));
        var serviceProvider = services.BuildServiceProvider();

        var mediatr = serviceProvider.GetRequiredService<ICqrsMediatr>();

        // Test Query
        var queryResult = await mediatr.QueryAsync(new TestQuery());
        Console.WriteLine($"Query Result: {queryResult}");

        // Test Command
        var commandResult = await mediatr.SendAsync(new TestCommand());
        Console.WriteLine($"Command Result: {commandResult}");
    }
}
