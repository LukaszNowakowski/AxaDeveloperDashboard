namespace Avanssur.AxaDeveloperDashboard.Api.Logic.EnvironmentsManagement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Avanssur.AxaDeveloperDashboard.Api.DataAccess.Cqrs;
    using Avanssur.AxaDeveloperDashboard.Api.DataAccess.Environments;

    public class EnvironmentsService : IEnvironmentsService
    {
        private readonly IMediator mediator;

        public EnvironmentsService(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<FetchEnvironmentsResponse> FetchEnvironments(FetchEnvironmentsRequest request)
        {
            var query = new FetchLinksQuery(request.UserName);
            var queryResult = await this.mediator.Query(query);
            var environments = queryResult
                .Select(li => new EnvironmentData(li.EnvironmentId, li.EnvironmentName))
                .Distinct(EnvironmentDataEqualityComparer.Default);
            var result = environments
                .Select(e =>
                {
                    var links = queryResult
                        .Where(l => l.EnvironmentId == e.Id);
                    return new Environment(e.Id, e.Name, links.Select(l => new Link(l.LinkId, l.LinkName, l.LinkIcon, l.Url)).ToArray());
                });
            return new FetchEnvironmentsResponse(result.ToArray());
        }

        private class EnvironmentData
        {
            public EnvironmentData(int id, string name)
            {
                this.Id = id;
                this.Name = name;
            }

            public int Id { get; }

            public string Name { get; }
        }

        private class EnvironmentDataEqualityComparer : IEqualityComparer<EnvironmentData>
        {
            private EnvironmentDataEqualityComparer()
            {
            }

            public static EnvironmentDataEqualityComparer Default = new EnvironmentDataEqualityComparer();

            public bool Equals(EnvironmentData x, EnvironmentData y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id == y.Id && x.Name == y.Name;
            }

            public int GetHashCode(EnvironmentData obj)
            {
                return HashCode.Combine(obj.Id, obj.Name);
            }
        }
    }
}
