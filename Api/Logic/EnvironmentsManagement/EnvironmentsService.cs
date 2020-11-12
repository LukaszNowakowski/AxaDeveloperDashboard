namespace Avanssur.AxaDeveloperDashboard.Api.Logic.EnvironmentsManagement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
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

        public async Task<FetchEnvironmentsResponse> FetchEnvironments(FetchEnvironmentsRequest request, CancellationToken cancellationToken)
        {
            var environmentsTask =
                this.mediator.Query<FetchEnvironmentsQuery, List<EnvironmentInformation>>(
                    new FetchEnvironmentsQuery(request.UserName), cancellationToken);
            var linksTask = this.mediator.Query<FetchLinksQuery, List<LinkInformation>>(
                new FetchLinksQuery(request.UserName), cancellationToken);
            await Task.WhenAll(environmentsTask, linksTask);
            var result = environmentsTask.Result
                .Select(e =>
                {
                    var links = linksTask.Result
                        .Where(l => l.EnvironmentId == e.EnvironmentId)
                        .Select(l => new Link(l.LinkId, l.LinkName, l.LinkIcon, l.Url, l.LinkOrder));
                    return new Environment(e.EnvironmentId, e.EnvironmentName, e.EnvironmentOrder, links.ToArray());
                });
            return new FetchEnvironmentsResponse(result.ToArray());
        }

        public async Task<AddEnvironmentResponse> AddEnvironment(
            AddEnvironmentRequest request,
            CancellationToken cancellationToken)
        {
            var environments =
                await this.FetchEnvironments(new FetchEnvironmentsRequest(request.UserName), cancellationToken);
            var command = new AddEnvironmentCommand(request.Environment.DisplayName, environments.Environments.Max(e => e.Order + 1));
            await this.mediator.Handle(command, cancellationToken);
            return new AddEnvironmentResponse(true);
        }

        private class EnvironmentData
        {
            public EnvironmentData(int id, string name, int order)
            {
                this.Id = id;
                this.Name = name;
                this.Order = order;
            }

            public int Id { get; }

            public string Name { get; }

            public int Order { get; }
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
