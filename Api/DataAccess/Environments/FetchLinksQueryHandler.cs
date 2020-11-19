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
                new[] {new CommandParameter("userIdParam", query.UserId)},
                r => new LinkInformation(
                    (int)r["EnvironmentId"],
                    (int)r["LinkId"],
                    (string)r["LinkName"],
                    (string)r["LinkIcon"],
                    (string)r["Url"],
                    (int)r["LinkOrder"]),
                null,
                cancellationToken);
            return result.ToList();
        }
    }
}
