namespace Avanssur.AxaDeveloperDashboard.Api.Logic.EnvironmentsManagement
{
    public class AddEnvironmentRequest
    {
        public AddEnvironmentRequest(string userName, Environment environment)
        {
            this.UserName = userName;
            this.Environment = environment;
        }

        public string UserName { get; }

        public Environment Environment { get; }
    }
}
