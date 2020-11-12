namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Environments
{
    using Avanssur.AxaDeveloperDashboard.Api.DataAccess.Cqrs;

    public class AddEnvironmentCommand : ICommand
    {
        public AddEnvironmentCommand(string displayName, int order)
        {
            this.DisplayName = displayName;
            this.Order = order;
        }

        public string DisplayName { get; }

        public int Order { get; }
    }
}
