using CQRSMediatr.Interfaces;

namespace CQRSMediatr.TestApp.Features;

public class TestCommand : ICommand<string> { }

public class TestCommandHandler : ICommandHandler<TestCommand, string>
{
    public Task<string> HandleAsync(TestCommand command, CancellationToken cancellationToken)
    {
        return Task.FromResult("Command Handled Successfully");
    }
}