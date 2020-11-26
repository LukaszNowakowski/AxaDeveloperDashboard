namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Environments
{
    using System.Collections.Generic;
    using Avanssur.AxaDeveloperDashboard.Api.DataAccess.Cqrs;

    public class FetchLinksQuery : IQuery<List<LinkInformation>>
    {
        public FetchLinksQuery(
            string userName)
        {
            this.UserName = userName;
        }

        public string UserName { get; }
    }
}
