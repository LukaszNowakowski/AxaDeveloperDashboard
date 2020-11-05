namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Cqrs
{
    using System.Threading.Tasks;

    public interface IMediator
    {
        Task<TResult> Query<TResult>(IQuery<TResult> query)
            where TResult : class;
    }
}
