namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Cqrs
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IMediator
    {
        Task<TResult> Query<TQuery, TResult>(TQuery query, CancellationToken cancellationToken)
            where TResult : class
            where TQuery : IQuery<TResult>;

        Task Handle<TCommand>(TCommand command, CancellationToken cancellationToken)
            where TCommand : ICommand;
    }
}
