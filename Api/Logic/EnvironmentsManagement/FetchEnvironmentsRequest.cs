namespace Avanssur.AxaDeveloperDashboard.Api.Logic.EnvironmentsManagement
{
    public class FetchEnvironmentsRequest
    {
        public FetchEnvironmentsRequest(string userName)
        {
            this.UserName = userName;
        }

        public string UserName { get; }
    }
}
