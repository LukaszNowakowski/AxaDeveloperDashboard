namespace Avanssur.AxaDeveloperDashboard.Api.Logic.Security
{
    public class CreateAccountRequest
    {
        public CreateAccountRequest(
            string userName,
            string displayName,
            string password)
        {
            this.UserName = userName;
            this.DisplayName = displayName;
            this.Password = password;
        }

        public string UserName { get; }

        public string DisplayName { get; }

        public string Password { get; }
    }
}
