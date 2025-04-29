using CQRSMediatr.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSMediatr;

public class CqrsMediatr : ICqrsMediatr
{
    private readonly IServiceProvider _serviceProvider;

    public CqrsMediatr(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
    {
        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
        dynamic handler = _serviceProvider.GetRequiredService(handlerType);

        return await handler.HandleAsync((dynamic)query).ConfigureAwait(false);
    }

    public async Task<TResult> SendAsync<TResult>(ICommand<TResult> command)
    {
        var handlerType = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResult));
        dynamic handler = _serviceProvider.GetRequiredService(handlerType);

        return await handler.HandleAsync((dynamic)command).ConfigureAwait(false);
    }
}