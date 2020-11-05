namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Cqrs
{
    using System.Threading.Tasks;

    public interface IQueryHandler<TResult>
        where TResult : class
    {
        Task<TResult> Handle(IQuery<TResult> query);
    }
}
