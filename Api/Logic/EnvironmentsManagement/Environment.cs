namespace Avanssur.AxaDeveloperDashboard.Api.Logic.EnvironmentsManagement
{
    using System.Collections.ObjectModel;
    using System.Linq;

    public class Environment
    {
        public Environment(int id, string displayName, int order, params Link[] links)
        {
            this.Id = id;
            this.DisplayName = displayName;
            this.Order = order;
            this.Links = new ReadOnlyCollection<Link>((links ?? Enumerable.Empty<Link>()).ToList());
        }

        public int Id { get; }

        public string DisplayName { get; }

        public int Order { get; }

        public ReadOnlyCollection<Link> Links { get; }
    }
}
