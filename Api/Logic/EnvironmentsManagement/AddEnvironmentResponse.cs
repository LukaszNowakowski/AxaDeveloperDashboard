namespace Avanssur.AxaDeveloperDashboard.Api.Logic.EnvironmentsManagement
{
    public class AddEnvironmentResponse
    {
        public AddEnvironmentResponse(bool created)
        {
            this.Created = created;
        }

        public bool Created { get; }
    }
}
