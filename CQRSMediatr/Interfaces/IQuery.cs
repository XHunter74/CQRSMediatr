namespace CQRSMediatr.Interfaces;

/// <summary>
/// Represents a query that returns a result of type <typeparamref name="TResult"/>.
/// Used in the CQRS pattern to encapsulate a read operation.
/// </summary>
/// <typeparam name="TResult">
/// The type of the result returned by the query.
/// </typeparam>
public interface IQuery<TResult> { }
