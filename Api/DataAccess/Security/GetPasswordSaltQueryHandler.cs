namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Security
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using Avanssur.AxaDeveloperDashboard.Api.DataAccess.Cqrs;
    using Avanssur.AxaDeveloperDashboard.Api.DataAccess.DbConnector;

    public class GetPasswordSaltQueryHandler : IQueryHandler<GetPasswordSaltQuery, GetPasswordSaltResult>
    {
        private readonly IPersistence persistence;

        public GetPasswordSaltQueryHandler(
            IPersistenceProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            this.persistence = provider.Create("AxaDashboard");
        }

        public async Task<GetPasswordSaltResult> Handle(GetPasswordSaltQuery query, CancellationToken cancellationToken)
        {
            var result = await this.persistence.RetrieveDataAsync(
                "GetPasswordSalt",
                new[]
                {
                    new CommandParameter("userNameParam", query.UserName)
                },
                r => new GetPasswordSaltResult(
                    (byte[])r["passwordSalt"]),
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
                    "Multiple salts found for user '{0}'",
                    query.UserName);
                throw new InvalidOperationException(message);
            }

            return result[0];
        }
    }
}
