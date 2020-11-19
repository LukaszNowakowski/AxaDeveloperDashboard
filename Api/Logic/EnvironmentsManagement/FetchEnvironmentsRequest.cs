namespace Avanssur.AxaDeveloperDashboard.Api.Logic.EnvironmentsManagement
{
    public class FetchEnvironmentsRequest
    {
        public FetchEnvironmentsRequest(int userId)
        {
            this.UserId = userId;
        }

        public int UserId { get; }
    }
}
