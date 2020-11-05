namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Environments
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Avanssur.AxaDeveloperDashboard.Api.DataAccess.Cqrs;

    public class FetchLinksQueryHandler : IQueryHandler<List<LinkInformation>>
    {
        public Task<List<LinkInformation>> Handle(IQuery<List<LinkInformation>> query)
        {
            var result = new List<LinkInformation>();
            result.Add(new LinkInformation(1, "LOCAL", 1, "CSA", "dashboard", "http://localhost/CustomerService"));
            result.Add(new LinkInformation(1, "LOCAL", 2, "Private Domain", "account_circle", "http://localhost/Sandpiper.UI.FrontOffice/AGDF/DirectAssurance/Motor/Standard/Desktop/LogOn/initLogOn"));
            result.Add(new LinkInformation(1, "LOCAL", 3, "Tools", "build", "http://localhost/Sandpiper.UI.Tools"));
            result.Add(new LinkInformation(2, "DIT01", 4, "CSA", "dashboard", "http://ext-env1.ppglobaldirect.intraxa/CustomerService"));
            result.Add(new LinkInformation(2, "DIT01", 5, "Private Domain", "account_circle", "http://www-env1.ppglobaldirect.intraxa/Sales/AGDF/DirectAssurance/Motor/Standard/Desktop/LogOn/initLogOn"));
            result.Add(new LinkInformation(2, "DIT01", 6, "Tools", "build", "http://ext-env1.ppglobaldirect.intraxa/Tools"));
            result.Add(new LinkInformation(3, "DIT02", 4, "CSA", "dashboard", "http://ext-env3.ppglobaldirect.intraxa/CustomerService"));
            result.Add(new LinkInformation(3, "DIT02", 5, "Private Domain", "account_circle", "http://www-env3.ppglobaldirect.intraxa/Sales/AGDF/DirectAssurance/Motor/Standard/Desktop/LogOn/initLogOn"));
            result.Add(new LinkInformation(3, "DIT02", 6, "Tools", "build", "http://ext-env3.ppglobaldirect.intraxa/Tools"));
            return Task.FromResult(result);
        }
    }
}
