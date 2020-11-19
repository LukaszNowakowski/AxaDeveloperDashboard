namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Environments
{
    using Avanssur.AxaDeveloperDashboard.Api.DataAccess.Cqrs;

    public class AddEnvironmentCommand : ICommand
    {
        public AddEnvironmentCommand(
            int userId,
            string displayName,
            int order)
        {
            this.UserId = userId;
            this.DisplayName = displayName;
            this.Order = order;
        }

        public int UserId { get; }

        public string DisplayName { get; }

        public int Order { get; }
    }
}
