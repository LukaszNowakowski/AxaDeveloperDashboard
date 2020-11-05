namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Cqrs
{
    public interface IHandlerFactory
    {
        IQueryHandler<TResult> CreateQueryHandler<TResult>()
            where TResult : class;
    }
}
