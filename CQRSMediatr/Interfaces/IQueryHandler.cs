namespace CQRSMediatr.Interfaces;

/// <summary>
/// Defines a handler for a query in the CQRS pattern.
/// </summary>
/// <typeparam name="TQuery">The type of query.</typeparam>
/// <typeparam name="TResult">The type of result returned by the handler.</typeparam>
public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
{
    /// <summary>
    /// Handles the specified query asynchronously.
    /// </summary>
    /// <param name="query">The query to handle.</param>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation, containing the result.</returns>
    Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken);
}
