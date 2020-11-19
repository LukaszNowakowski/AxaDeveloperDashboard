namespace Avanssur.AxaDeveloperDashboard.Api.Logic.Security
{
    public class PasswordInformation
    {
        private readonly byte[] hash;

        private readonly byte[] salt;

        public PasswordInformation(
            byte[] hash,
            byte[] salt)
        {
            this.hash = hash;
            this.salt = salt;
        }

        public byte[] GetHash()
        {
            return (byte[])this.hash.Clone();
        }

        public byte[] GetSalt()
        {
            return (byte[])this.salt.Clone();
        }
    }
}
