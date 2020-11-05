﻿namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Cqrs
{
    using System;
    using System.Globalization;
    using System.Threading.Tasks;

    public class Mediator : IMediator
    {
        private readonly IHandlerFactory handlerFactory;

        public Mediator(
            IHandlerFactory handlerFactory)
        {
            this.handlerFactory = handlerFactory ?? throw new ArgumentNullException(nameof(handlerFactory));
        }

        public async Task<TResult> Query<TResult>(IQuery<TResult> query) where TResult : class
        {
            var handler = this.handlerFactory.CreateQueryHandler<TResult>();
            if (handler == null)
            {
                var message = string.Format(
                    CultureInfo.InvariantCulture,
                    "Missing handler for result '{0}'",
                    typeof(TResult).FullName);
                throw new InvalidOperationException(message);
            }

            var result = await handler.Handle(query);
            return result;
        }
    }
}
