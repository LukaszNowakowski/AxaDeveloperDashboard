namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Security
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Avanssur.AxaDeveloperDashboard.Api.DataAccess.Cqrs;
    using Avanssur.AxaDeveloperDashboard.Api.DataAccess.DbConnector;

    public class VerifyCredentialsQueryHandler : IQueryHandler<VerifyCredentialsQuery, VerifyCredentialsResult>
    {
        private readonly IPersistence persistence;

        public VerifyCredentialsQueryHandler(
            IPersistenceProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            this.persistence = provider.Create("AxaDashboard");
        }

        public async Task<VerifyCredentialsResult> Handle(VerifyCredentialsQuery query, CancellationToken cancellationToken)
        {
            var result = await this.persistence.RetrieveDataAsync(
                "VerifyCredentials",
                new[]
                {
                    new CommandParameter("userNameParam", query.UserName),
                    new CommandParameter("passwordParam", query.Password)
                },
                r => new VerifyCredentialsResult(
                    (int)r["entriesCount"]),
                null,
                cancellationToken);
            if (result.Count == 0)
            {
                return null;
            }

            if (result.Count > 1)
            {
                var message = string.Format(
                    CultureInfo.InvariantCulture,
                    "Multiple entries found for user '{0}'",
                    query.UserName);
                throw new InvalidOperationException(message);
            }

            return result[0];
        }
    }
}
