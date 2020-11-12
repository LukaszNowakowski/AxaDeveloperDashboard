﻿namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Cqrs
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface ICommandHandler<in TCommand>
        where TCommand : ICommand
    {
        Task Handle(TCommand command, CancellationToken cancellationToken);
    }
}
