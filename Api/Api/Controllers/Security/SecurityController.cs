namespace Avanssur.AxaDeveloperDashboard.Api.Controllers.Security
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Avanssur.AxaDeveloperDashboard.Api.Logic.Security;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("security")]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService securityService;

        public SecurityController(
            ISecurityService securityService)
        {
            this.securityService = securityService ?? throw new ArgumentNullException(nameof(securityService));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountInput input, CancellationToken cancellationToken)
        {
            var request = new CreateAccountRequest(input.UserName, input.DisplayName, input.Password);
            var response = await this.securityService.CreateAccount(request, cancellationToken);
            return this.Ok(new CreateAccountOutput(response.Id.HasValue));
        }

        [Route("createToken")]
        [HttpPost]
        public async Task<IActionResult> VerifyCredentials(
            [FromBody] VerifyCredentialsInput input,
            CancellationToken cancellationToken)
        {
            var request = new VerifyCredentialsRequest(input.UserName, input.Password);
            var response = await this.securityService.VerifyCredentials(request, cancellationToken);
            return this.Ok(new VerifyCredentialsResponse(response.CredentialsValid, response.Token));
        }
    }
}
