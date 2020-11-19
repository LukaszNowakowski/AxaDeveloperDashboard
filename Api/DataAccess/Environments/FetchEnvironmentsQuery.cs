namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Environments
{
    using System.Collections.Generic;
    using Avanssur.AxaDeveloperDashboard.Api.DataAccess.Cqrs;

    public class FetchEnvironmentsQuery : IQuery<List<EnvironmentInformation>>
    {
        public FetchEnvironmentsQuery(
            int userId)
        {
            this.UserId = userId;
        }

        public int UserId { get; }
    }
}
