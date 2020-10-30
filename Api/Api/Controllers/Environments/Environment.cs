namespace Avanssur.AxaDeveloperDashboard.Api.Controllers.Environments
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class Environment
    {
        public Environment(string displayName, params Link[] links)
        {
            this.DisplayName = displayName;
            this.Links = new ReadOnlyCollection<Link>((links ?? Enumerable.Empty<Link>()).ToList());
        }

        public string DisplayName { get; }

        public ReadOnlyCollection<Link> Links { get; }
    }
}
