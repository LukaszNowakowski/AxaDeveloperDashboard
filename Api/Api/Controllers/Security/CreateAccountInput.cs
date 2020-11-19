namespace Avanssur.AxaDeveloperDashboard.Api.Controllers.Security
{
    public class CreateAccountInput
    {
        public CreateAccountInput(
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
