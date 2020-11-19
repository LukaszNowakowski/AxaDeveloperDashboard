namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Security
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Avanssur.AxaDeveloperDashboard.Api.DataAccess.Cqrs;
    using Avanssur.AxaDeveloperDashboard.Api.DataAccess.DbConnector;

    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IPersistence persistence;

        public CreateUserCommandHandler(
            IPersistenceProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            this.persistence = provider.Create("AxaDashboard");
        }

        public async Task Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            await this.persistence.ExecuteOperationAsync(
                "CreateUser",
                new[]
                {
                    new CommandParameter("externalIdParam", command.ExternalId.ToByteArray()),
                    new CommandParameter("userNameParam", command.UserName),
                    new CommandParameter("passwordSaltParam", command.PasswordSalt),
                    new CommandParameter("passwordHashParam", command.PasswordHash),
                    new CommandParameter("displayNameParam", command.DisplayName),
                },
                null,
                cancellationToken);
        }
    }
}
