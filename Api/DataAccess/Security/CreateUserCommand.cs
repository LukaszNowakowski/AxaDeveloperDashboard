namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Security
{
    using System;
    using Avanssur.AxaDeveloperDashboard.Api.DataAccess.Cqrs;

    public class CreateUserCommand : ICommand
    {
        public CreateUserCommand(
            Guid externalId,
            string userName,
            byte[] passwordSalt,
            byte[] passwordHash,
            string displayName)
        {
            this.ExternalId = externalId;
            this.UserName = userName;
            this.PasswordSalt = passwordSalt;
            this.PasswordHash = passwordHash;
            this.DisplayName = displayName;
        }

        public Guid ExternalId { get; }

        public string UserName { get; }

        public byte[] PasswordSalt { get; }

        public byte[] PasswordHash { get; }

        public string DisplayName { get; }
    }
}
