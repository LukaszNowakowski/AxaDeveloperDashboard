namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Environments
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Avanssur.AxaDeveloperDashboard.Api.DataAccess.Cqrs;
    using Avanssur.AxaDeveloperDashboard.Api.DataAccess.DbConnector;

    public class AddEnvironmentCommandHandler : ICommandHandler<AddEnvironmentCommand>
    {
        private readonly IPersistence persistence;

        public AddEnvironmentCommandHandler(
            IPersistenceProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            this.persistence = provider.Create("AxaDashboard");
        }

        public async Task Handle(AddEnvironmentCommand command, CancellationToken cancellationToken)
        {
            await this.persistence.ExecuteOperationAsync(
                "AddEnvironment",
                new[]
                {
                    new CommandParameter("userNameParam", command.UserName),
                    new CommandParameter("displayNameParam", command.DisplayName),
                    new CommandParameter("orderParam", command.Order)
                },
                null,
                cancellationToken);
        }
    }
}
