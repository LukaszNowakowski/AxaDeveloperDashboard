namespace Avanssur.AxaDeveloperDashboard.Api.Controllers.Environments
{
    using System.Collections.ObjectModel;
    using System.Linq;

    public class FetchEnvironmentsOutput
    {
        public FetchEnvironmentsOutput(params Environment[] environments)
        {
            this.Environments = new ReadOnlyCollection<Environment>((environments ?? Enumerable.Empty<Environment>()).ToList());
        }

        public ReadOnlyCollection<Environment> Environments { get; }
    }
}
