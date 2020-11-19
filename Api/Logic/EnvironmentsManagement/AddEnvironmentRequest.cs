namespace Avanssur.AxaDeveloperDashboard.Api.Logic.EnvironmentsManagement
{
    public class AddEnvironmentRequest
    {
        public AddEnvironmentRequest(int userId, Environment environment)
        {
            this.UserId = userId;
            this.Environment = environment;
        }

        public int UserId { get; }

        public Environment Environment { get; }
    }
}
