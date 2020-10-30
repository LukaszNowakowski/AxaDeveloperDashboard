namespace Avanssur.AxaDeveloperDashboard.Api.Controllers.WorkItems
{
    using System.Globalization;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("workItems")]
    public class WorkItemsController : Controller
    {
        [Route("productionLogPath/{errorId}")]
        public IActionResult GetProductionLogPath(int errorId)
        {
            const string productionLogPathTemplate = "http://ext-prod2-darwin.globaldirect.intraxa/Tools/logs/logViewer/{0}";
            return this.Json(string.Format(CultureInfo.InvariantCulture, productionLogPathTemplate, errorId));
        }
    }
}
