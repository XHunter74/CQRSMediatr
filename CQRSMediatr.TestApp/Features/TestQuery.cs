using CQRSMediatr.Interfaces;

namespace CQRSMediatr.TestApp.Features;

public class TestQuery : IQuery<string> { }

public class TestQueryHandler : IQueryHandler<TestQuery, string>
{
    public Task<string> HandleAsync(TestQuery query, CancellationToken cancellationToken)
    {
        return Task.FromResult("Query Handled Successfully");
    }
}