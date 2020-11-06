namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Environments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Avanssur.AxaDeveloperDashboard.Api.DataAccess.Cqrs;
    using Avanssur.AxaDeveloperDashboard.Api.DataAccess.DbConnector;

    public class FetchLinksQueryHandler : IQueryHandler<FetchLinksQuery, List<LinkInformation>>
    {
        private readonly IPersistence persistence;

        public FetchLinksQueryHandler(
            IPersistenceProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            this.persistence = provider.Create("AxaDashboard");
        }

        public async Task<List<LinkInformation>> Handle(FetchLinksQuery query, CancellationToken cancellationToken)
        {
            var result = await this.persistence.RetrieveDataAsync(
                "FetchLinks",
                new[] {new CommandParameter("userNameParam", query.UserName)},
                r =>
                {
                    return new LinkInformation(
                        (int) r["EnvironmentId"],
                        (string) r["EnvironmentName"],
                        (int) r["LinkId"],
                        (string) r["LinkName"],
                        (string) r["LinkIcon"],
                        (string) r["Url"]);
                },
                null,
                cancellationToken);
            ////result.Add(new LinkInformation(1, "LOCAL", 1, "CSA", "dashboard", "http://localhost/CustomerService"));
            ////result.Add(new LinkInformation(1, "LOCAL", 2, "Private Domain", "account_circle", "http://localhost/Sandpiper.UI.FrontOffice/AGDF/DirectAssurance/Motor/Standard/Desktop/LogOn/initLogOn"));
            ////result.Add(new LinkInformation(1, "LOCAL", 3, "Tools", "build", "http://localhost/Sandpiper.UI.Tools"));
            ////result.Add(new LinkInformation(2, "DIT01", 4, "CSA", "dashboard", "http://ext-env1.ppglobaldirect.intraxa/CustomerService"));
            ////result.Add(new LinkInformation(2, "DIT01", 5, "Private Domain", "account_circle", "http://www-env1.ppglobaldirect.intraxa/Sales/AGDF/DirectAssurance/Motor/Standard/Desktop/LogOn/initLogOn"));
            ////result.Add(new LinkInformation(2, "DIT01", 6, "Tools", "build", "http://ext-env1.ppglobaldirect.intraxa/Tools"));
            ////result.Add(new LinkInformation(3, "DIT02", 4, "CSA", "dashboard", "http://ext-env3.ppglobaldirect.intraxa/CustomerService"));
            ////result.Add(new LinkInformation(3, "DIT02", 5, "Private Domain", "account_circle", "http://www-env3.ppglobaldirect.intraxa/Sales/AGDF/DirectAssurance/Motor/Standard/Desktop/LogOn/initLogOn"));
            ////result.Add(new LinkInformation(3, "DIT02", 6, "Tools", "build", "http://ext-env3.ppglobaldirect.intraxa/Tools"));
            return result.ToList();
        }
    }
}
