namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Cqrs
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    public class Mediator : IMediator
    {
        private readonly IHandlerFactory handlerFactory;

        public Mediator(
            IHandlerFactory handlerFactory)
        {
            this.handlerFactory = handlerFactory ?? throw new ArgumentNullException(nameof(handlerFactory));
        }

        public async Task<TResult> Query<TQuery, TResult>(TQuery query, CancellationToken cancellationToken)
            where TResult : class
            where TQuery : IQuery<TResult>
        {
            var handler = this.handlerFactory.CreateQueryHandler<TQuery, TResult>();
            if (handler == null)
            {
                var message = string.Format(
                    CultureInfo.InvariantCulture,
                    "Missing handler for result '{0}'",
                    typeof(TResult).FullName);
                throw new InvalidOperationException(message);
            }

            var result = await handler.Handle(query, cancellationToken);
            return result;
        }

        public async Task Handle<TCommand>(TCommand command, CancellationToken cancellationToken)
            where TCommand : ICommand
        {
            var handler = this.handlerFactory.CreateCommandHandler<TCommand>();
            if (handler == null)
            {
                var message = string.Format(
                    CultureInfo.InvariantCulture,
                    "Missing handler for command '{0}'",
                    typeof(TCommand).FullName);
                throw new InvalidOperationException(message);
            }

            await handler.Handle(command, cancellationToken);
        }
    }
}
