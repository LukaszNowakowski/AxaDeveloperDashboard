namespace Avanssur.AxaDeveloperDashboard.Api.Logic.Security
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Avanssur.AxaDeveloperDashboard.Api.DataAccess.Cqrs;
    using Avanssur.AxaDeveloperDashboard.Api.DataAccess.Security;
    using Avanssur.AxaDeveloperDashboard.Api.Logic.Security.Tokens;

    public class DefaultSecurityService : ISecurityService
    {
        private readonly ICryptographyProvider cryptographyProvider;

        private readonly IMediator mediator;

        private readonly ITokenGenerator tokenGenerator;

        private readonly ITokenValidator tokenValidator;

        public DefaultSecurityService(
            ICryptographyProvider cryptographyProvider,
            IMediator mediator,
            ITokenGenerator tokenGenerator,
            ITokenValidator tokenValidator)
        {
            this.cryptographyProvider =
                cryptographyProvider ?? throw new ArgumentNullException(nameof(cryptographyProvider));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.tokenGenerator = tokenGenerator ?? throw new ArgumentNullException(nameof(tokenGenerator));
            this.tokenValidator = tokenValidator ?? throw new ArgumentNullException(nameof(tokenValidator));
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

        public async Task<VerifyCredentialsResponse> VerifyCredentials(VerifyCredentialsRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var saltQuery = new GetPasswordSaltQuery(request.UserName);
            var saltData = await this.mediator.Query<GetPasswordSaltQuery, GetPasswordSaltResult>(saltQuery, cancellationToken)
                .ConfigureAwait(false);
            if (saltData == null)
            {
                return new VerifyCredentialsResponse(false, string.Empty);
            }

            var passwordHash = this.cryptographyProvider.CalculatePasswordHash(request.Password, saltData.PasswordSalt);
            var credentialsQuery = new VerifyCredentialsQuery(request.UserName, passwordHash);
            var credentialsVerificationResult = await this.mediator.Query<VerifyCredentialsQuery, VerifyCredentialsResult>(credentialsQuery, cancellationToken)
                .ConfigureAwait(false);
            if (credentialsVerificationResult.EntriesCount == 1)
            {
                var token = this.tokenGenerator.Create(new TokenData(request.UserName));
                return new VerifyCredentialsResponse(true, token);
            }

            return new VerifyCredentialsResponse(false, string.Empty);
        }
    }
}
