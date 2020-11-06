namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Cqrs
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IQueryHandler<in TQuery, TResult>
        where TResult : class
        where TQuery: IQuery<TResult>
    {
        Task<TResult> Handle(TQuery query, CancellationToken cancellationToken);
    }
}
