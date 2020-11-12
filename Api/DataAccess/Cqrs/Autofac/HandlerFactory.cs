namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Cqrs.Autofac
{
    using System;
    using global::Autofac;

    public class HandlerFactory : IHandlerFactory
    {
        private readonly ILifetimeScope lifetimeScope;

        public HandlerFactory(ILifetimeScope lifetimeScope)
        {
            this.lifetimeScope = lifetimeScope ?? throw new ArgumentNullException(nameof(lifetimeScope));
        }

        public IQueryHandler<TQuery, TResult> CreateQueryHandler<TQuery, TResult>()
            where TResult : class
            where TQuery : IQuery<TResult>
        {
            if (!this.lifetimeScope.TryResolve<IQueryHandler<TQuery, TResult>>(out var result))
            {
                return null;
            }

            return result;
        }

        public ICommandHandler<TCommand> CreateCommandHandler<TCommand>() where TCommand : ICommand
        {
            if (!this.lifetimeScope.TryResolve<ICommandHandler<TCommand>>(out var result))
            {
                return null;
            }

            return result;
        }
    }
}
