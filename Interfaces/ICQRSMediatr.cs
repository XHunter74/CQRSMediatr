namespace CQRSMediatr.Interfaces;

public interface ICqrsMediatr
{
    Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    Task<TResult> SendAsync<TResult>(ICommand<TResult> command);
}
