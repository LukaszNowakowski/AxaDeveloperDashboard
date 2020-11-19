namespace Avanssur.AxaDeveloperDashboard.Api.Controllers.Security
{
    public class VerifyCredentialsOutput
    {
        public VerifyCredentialsOutput(
            bool credentialsValid,
            string token)
        {
            this.CredentialsValid = credentialsValid;
            this.Token = token;
        }

        public bool CredentialsValid { get; }

        public string Token { get; }
    }
}
