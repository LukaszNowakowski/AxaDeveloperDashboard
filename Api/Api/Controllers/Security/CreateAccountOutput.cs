namespace Avanssur.AxaDeveloperDashboard.Api.Controllers.Security
{
    public class CreateAccountOutput
    {
        public CreateAccountOutput(
            bool created)
        {
            this.Created = created;
        }

        public bool Created { get; }
    }
}
