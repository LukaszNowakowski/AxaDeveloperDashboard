namespace Avanssur.AxaDeveloperDashboard.Api.Controllers.Environments
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using EnvironmentsManagement = Avanssur.AxaDeveloperDashboard.Api.Logic.EnvironmentsManagement;
    using Microsoft.AspNetCore.Mvc;

    [Route("environments")]
    [ApiController]
    public class EnvironmentsController : ControllerBase
    {
        private readonly EnvironmentsManagement.IEnvironmentsService environmentsService;

        public EnvironmentsController(
            EnvironmentsManagement.IEnvironmentsService environmentsService)
        {
            this.environmentsService =
                environmentsService ?? throw new ArgumentNullException(nameof(environmentsService));
        }
        [HttpGet]
        public async Task<IActionResult> FetchEnvironments(CancellationToken cancellationToken)
        {
            var request = new EnvironmentsManagement.FetchEnvironmentsRequest(-1);
            var response = await this.environmentsService.FetchEnvironments(request, cancellationToken);
            var result = new FetchEnvironmentsOutput(
                response.Environments.Select(Map).ToArray());
            return this.Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddEnvironment([FromBody]Environment environment, CancellationToken cancellationToken)
        {
            var request = new EnvironmentsManagement.AddEnvironmentRequest(
                -1,
                new EnvironmentsManagement.Environment(-1, environment.DisplayName, -1));
            var response = await this.environmentsService.AddEnvironment(request, cancellationToken);
            var result = new AddEnvironmentOutput(response.Created);
            return this.Ok(result);
        }

        private static Link Map(EnvironmentsManagement.Link link)
        {
            return new Link(
                link.Id,
                link.DisplayName,
                link.Icon,
                link.Url);
        }

        private static Environment Map(EnvironmentsManagement.Environment environment)
        {
            return new Environment(
                environment.Id,
                environment.DisplayName,
                environment.Links.Select(Map).ToArray());
        }
    }
}
