namespace Avanssur.AxaDeveloperDashboard.Api.Logic.EnvironmentsManagement
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IEnvironmentsService
    {
        Task<FetchEnvironmentsResponse> FetchEnvironments(FetchEnvironmentsRequest request, CancellationToken cancellationToken);
    }
}
