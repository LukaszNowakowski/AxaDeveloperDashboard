namespace Avanssur.AxaDeveloperDashboard.Api.Logic.Security
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Avanssur.AxaDeveloperDashboard.Api.DataAccess.Cqrs;
    using Avanssur.AxaDeveloperDashboard.Api.DataAccess.Security;

    public class DefaultSecurityService : ISecurityService
    {
        private readonly ICryptographyProvider cryptographyProvider;

        private readonly IMediator mediator;

        public DefaultSecurityService(
            ICryptographyProvider cryptographyProvider,
            IMediator mediator)
        {
            this.cryptographyProvider =
                cryptographyProvider ?? throw new ArgumentNullException(nameof(cryptographyProvider));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<CreateAccountResponse> CreateAccount(CreateAccountRequest request, CancellationToken cancellationToken)
        {
            var userId = Guid.NewGuid();
            var passwordInformation = this.cryptographyProvider.GeneratePasswordInformation(request.Password);
            var command = new CreateUserCommand(
                userId,
                request.UserName,
                passwordInformation.GetSalt(),
                passwordInformation.GetHash(),
                request.DisplayName);
            await this.mediator.Handle(command, cancellationToken);
            return new CreateAccountResponse(userId);
        }
    }
}
