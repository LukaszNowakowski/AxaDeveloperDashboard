namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Environments
{
    using Avanssur.AxaDeveloperDashboard.Api.DataAccess.Cqrs;

    public class AddEnvironmentCommand : ICommand
    {
        public AddEnvironmentCommand(
            string userName,
            string displayName,
            int order)
        {
            this.UserName = userName;
            this.DisplayName = displayName;
            this.Order = order;
        }

        public string UserName { get; }

        public string DisplayName { get; }

        public int Order { get; }
    }
}
