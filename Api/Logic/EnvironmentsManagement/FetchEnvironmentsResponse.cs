namespace Avanssur.AxaDeveloperDashboard.Api.Logic.EnvironmentsManagement
{
    using System.Collections.ObjectModel;
    using System.Linq;

    public class FetchEnvironmentsResponse
    {
        public FetchEnvironmentsResponse(params Environment[] environments)
        {
            this.Environments = new ReadOnlyCollection<Environment>((environments ?? Enumerable.Empty<Environment>()).ToList());
        }

        public ReadOnlyCollection<Environment> Environments { get; }
    }
}
