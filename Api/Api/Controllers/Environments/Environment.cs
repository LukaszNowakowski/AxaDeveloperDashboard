namespace Avanssur.AxaDeveloperDashboard.Api.Controllers.Environments
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class Environment
    {
        public Environment(int id, string displayName, params Link[] links)
        {
            this.Id = id;
            this.DisplayName = displayName;
            this.Links = new ReadOnlyCollection<Link>((links ?? Enumerable.Empty<Link>()).ToList());
        }

        public int Id { get; }

        public string DisplayName { get; }

        public ReadOnlyCollection<Link> Links { get; }
    }
}
