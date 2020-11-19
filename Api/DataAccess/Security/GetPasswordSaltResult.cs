namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Security
{
    public class GetPasswordSaltResult
    {
        public GetPasswordSaltResult(byte[] passwordSalt)
        {
            this.PasswordSalt = passwordSalt;
        }

        public byte[] PasswordSalt { get; }
    }
}
