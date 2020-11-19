namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Environments
{
    using System.Collections.Generic;
    using Avanssur.AxaDeveloperDashboard.Api.DataAccess.Cqrs;

    public class FetchLinksQuery : IQuery<List<LinkInformation>>
    {
        public FetchLinksQuery(
            int userId)
        {
            this.UserId = userId;
        }

        public int UserId { get; }
    }
}
