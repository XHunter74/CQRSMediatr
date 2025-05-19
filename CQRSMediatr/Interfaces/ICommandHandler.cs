namespace CQRSMediatr.Interfaces;

/// <summary>
/// Defines a handler for a command in the CQRS pattern.
/// </summary>
/// <typeparam name="TCommand">The type of command.</typeparam>
/// <typeparam name="TResult">The type of result returned by the handler.</typeparam>
public interface ICommandHandler<TCommand, TResult> where TCommand : ICommand<TResult>
{
    /// <summary>
    /// Handles the specified command asynchronously.
    /// </summary>
    /// <param name="query">The command to handle.</param>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation, containing the result.</returns>
    Task<TResult> HandleAsync(TCommand query, CancellationToken cancellationToken);
}
