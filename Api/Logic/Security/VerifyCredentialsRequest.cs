namespace Avanssur.AxaDeveloperDashboard.Api.Logic.Security
{
    public class VerifyCredentialsRequest
    {
        public VerifyCredentialsRequest(
            string userName,
            string password)
        {
            this.UserName = userName;
            this.Password = password;
        }

        public string UserName { get; }

        public string Password { get; }
    }
}
