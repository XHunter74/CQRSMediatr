using CQRSMediatr.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSMediatr.Test;

public class TestQuery : IQuery<string> { }

public class TestQueryHandler : IQueryHandler<TestQuery, string>
{
    public Task<string> HandleAsync(TestQuery query, CancellationToken cancellationToken)
    {
        return Task.FromResult("Test Result");
    }
}

public class TestCommand : ICommand<string> { }

public class TestCommandHandler : ICommandHandler<TestCommand, string>
{
    public Task<string> HandleAsync(TestCommand command, CancellationToken cancellationToken)
    {
        return Task.FromResult("Command Result");
    }
}

public class CqrsMediatrTests
{
    [Fact]
    public async Task QueryAsync_Should_Invoke_Handler()
    {
        // Arrange
        var services = new ServiceCollection();
        services.AddCqrsMediatr(typeof(CqrsMediatrTests));
        var serviceProvider = services.BuildServiceProvider();

        var mediatr = serviceProvider.GetRequiredService<ICqrsMediatr>();

        var query = new TestQuery();

        // Act
        var result = await mediatr.QueryAsync(query);

        // Assert
        Assert.Equal("Test Result", result);
    }

    [Fact]
    public async Task SendAsync_Should_Invoke_Handler()
    {
        // Arrange
        var services = new ServiceCollection();
        services.AddCqrsMediatr(typeof(CqrsMediatrTests));
        var serviceProvider = services.BuildServiceProvider();

        var mediatr = serviceProvider.GetRequiredService<ICqrsMediatr>();

        var command = new TestCommand();

        // Act
        var result = await mediatr.SendAsync(command);

        // Assert
        Assert.Equal("Command Result", result);
    }
}
