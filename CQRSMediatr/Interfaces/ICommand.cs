namespace CQRSMediatr.Interfaces;

/// <summary>
/// Marker interface representing a command in the CQRS pattern.
/// </summary>
/// <typeparam name="TResult">The type of result returned by the command handler.</typeparam>
public interface ICommand<TResult> { }
