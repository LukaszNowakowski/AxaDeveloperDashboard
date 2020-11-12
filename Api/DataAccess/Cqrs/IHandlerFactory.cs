namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Cqrs
{
    public interface IHandlerFactory
    {
        IQueryHandler<TQuery, TResult> CreateQueryHandler<TQuery, TResult>()
            where TResult : class
            where TQuery : IQuery<TResult>;

        ICommandHandler<TCommand> CreateCommandHandler<TCommand>()
            where TCommand : ICommand;
    }
}
