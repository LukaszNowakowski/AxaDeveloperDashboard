namespace Avanssur.AxaDeveloperDashboard.Api.Logic.Security.Tokens
{
    public class TokenData
    {
        public TokenData(
            string userName)
        {
            this.UserName = userName;
        }

        public string UserName { get; }
    }
}
