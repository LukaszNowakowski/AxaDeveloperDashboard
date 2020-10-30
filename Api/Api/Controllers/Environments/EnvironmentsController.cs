namespace Avanssur.AxaDeveloperDashboard.Api.Controllers.Environments
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class EnvironmentsController : ControllerBase
    {
        [Route("environments")]
        [HttpGet]
        public Task<IActionResult> FetchEnvironments()
        {
            var result = new FetchEnvironmentsResponse(
                new Environment(
                    "DIT01",
                    new Link(
                        "CSA",
                        "dashboard",
                        "http://ext-env1.ppglobaldirect.intraxa/CustomerService"),
                    new Link(
                        "Private Domain",
                        "account_circle",
                        "http://www-env1.ppglobaldirect.intraxa/Sales/AGDF/DirectAssurance/Motor/Standard/Desktop/LogOn/initLogOn"),
                    new Link(
                        "Tools",
                        "build",
                        "http://ext-env1.ppglobaldirect.intraxa/Tools")),
                new Environment(
                    "DIT02",
                    new Link(
                        "CSA",
                        "dashboard",
                        "http://ext-env3.ppglobaldirect.intraxa/CustomerService"),
                    new Link(
                        "Private Domain",
                        "account_circle",
                        "http://www-env3.ppglobaldirect.intraxa/Sales/AGDF/DirectAssurance/Motor/Standard/Desktop/LogOn/initLogOn"),
                    new Link(
                        "Tools",
                        "build",
                        "http://ext-env3.ppglobaldirect.intraxa/Tools")));
            return Task.FromResult<IActionResult>(this.Ok(result));
        }
    }
}
