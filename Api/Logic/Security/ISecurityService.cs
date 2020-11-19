namespace Avanssur.AxaDeveloperDashboard.Api.Logic.Security
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface ISecurityService
    {
        Task<CreateAccountResponse> CreateAccount(
            CreateAccountRequest request,
            CancellationToken cancellationToken);

        Task<VerifyCredentialsResponse> VerifyCredentials(
            VerifyCredentialsRequest request,
            CancellationToken cancellationToken);
    }
}
