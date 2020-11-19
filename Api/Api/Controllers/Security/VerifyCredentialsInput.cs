namespace Avanssur.AxaDeveloperDashboard.Api.Controllers.Security
{
    public class VerifyCredentialsInput
    {
        public VerifyCredentialsInput(
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
