namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Environments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Avanssur.AxaDeveloperDashboard.Api.DataAccess.Cqrs;
    using Avanssur.AxaDeveloperDashboard.Api.DataAccess.DbConnector;

    class FetchEnvironmentsQueryHandler : IQueryHandler<FetchEnvironmentsQuery, List<EnvironmentInformation>>
    {
        private readonly IPersistence persistence;

        public FetchEnvironmentsQueryHandler(
            IPersistenceProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            this.persistence = provider.Create("AxaDashboard");
        }

        public async Task<List<EnvironmentInformation>> Handle(FetchEnvironmentsQuery query, CancellationToken cancellationToken)
        {
            var result = await this.persistence.RetrieveDataAsync(
                "FetchEnvironments",
                new[] { new CommandParameter("userNameParam", query.UserName) },
                r =>
                {
                    return new EnvironmentInformation(
                        (int) r["EnvironmentId"],
                        (string) r["EnvironmentName"],
                        (int) r["EnvironmentOrder"]);
                },
                null,
                cancellationToken);
            return result.ToList();
        }
    }
}
