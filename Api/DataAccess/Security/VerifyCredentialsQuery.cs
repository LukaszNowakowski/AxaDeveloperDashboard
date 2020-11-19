namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Security
{
    using Avanssur.AxaDeveloperDashboard.Api.DataAccess.Cqrs;

    public class VerifyCredentialsQuery : IQuery<VerifyCredentialsResult>
    {
        public VerifyCredentialsQuery(
            string userName,
            byte[] password)
        {
            this.UserName = userName;
            this.Password = password;
        }

        public string UserName { get; }

        public byte[] Password { get; }
    }
}
