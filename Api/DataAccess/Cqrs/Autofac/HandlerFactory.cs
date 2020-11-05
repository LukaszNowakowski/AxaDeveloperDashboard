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

        public IQueryHandler<TResult> CreateQueryHandler<TResult>() where TResult : class
        {
            if (!this.lifetimeScope.TryResolve<IQueryHandler<TResult>>(out var result))
            {
                return null;
            }

            return result;
        }
    }
}
