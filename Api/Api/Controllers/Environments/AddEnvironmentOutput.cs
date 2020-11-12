namespace Avanssur.AxaDeveloperDashboard.Api.Controllers.Environments
{
    public class AddEnvironmentOutput
    {
        public AddEnvironmentOutput(bool created)
        {
            this.Created = created;
        }

        public bool Created { get; }
    }
}
