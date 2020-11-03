namespace Avanssur.AxaDeveloperDashboard.Api.Logic.EnvironmentsManagement
{
    using System.Threading.Tasks;

    public class EnvironmentsService : IEnvironmentsService
    {
        public Task<FetchEnvironmentsResponse> FetchEnvironments(FetchEnvironmentsRequest request)
        {
            var result = new FetchEnvironmentsResponse(
                 new Environment(
                     "LOCAL",
                     new Link(
                         "CSA",
                         "dashboard",
                         "http://localhost/CustomerService"),
                     new Link(
                         "Private Domain",
                         "account_circle",
                         "http://localhost/Sandpiper.UI.FrontOffice/AGDF/DirectAssurance/Motor/Standard/Desktop/LogOn/initLogOn"),
                     new Link(
                         "Tools",
                         "build",
                         "http://localhost/Sandpiper.UI.Tools")),
                 new Environment(
                     "DIT01",
                     new Link(
                         "CSA",
                         "dashboard",
                         "http://ext-env1.ppglobaldirect.intraxa/CustomerService"),
                     new Link(
                         "Private Domain",
                         "account_circle",
                         "http://www-env1.ppglobaldirect.intraxa/Sales/AGDF/DirectAssurance/Motor/Standard/Desktop/LogOn/initLogOn"),
                     new Link(
                         "Tools",
                         "build",
                         "http://ext-env1.ppglobaldirect.intraxa/Tools")),
                 new Environment(
                     "DIT02",
                     new Link(
                         "CSA",
                         "dashboard",
                         "http://ext-env3.ppglobaldirect.intraxa/CustomerService"),
                     new Link(
                         "Private Domain",
                         "account_circle",
                         "http://www-env3.ppglobaldirect.intraxa/Sales/AGDF/DirectAssurance/Motor/Standard/Desktop/LogOn/initLogOn"),
                     new Link(
                         "Tools",
                         "build",
                         "http://ext-env3.ppglobaldirect.intraxa/Tools")));
            return Task.FromResult(result);
        }
    }
}
