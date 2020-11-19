namespace Avanssur.AxaDeveloperDashboard.Api.Logic.Security
{
    public class VerifyCredentialsResponse
    {
        public VerifyCredentialsResponse(
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
