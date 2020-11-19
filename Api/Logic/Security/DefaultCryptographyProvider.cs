namespace Avanssur.AxaDeveloperDashboard.Api.Logic.Security
{
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class DefaultCryptographyProvider : ICryptographyProvider
    {
        private const int SaltSize = 128;

        public PasswordInformation GeneratePasswordInformation(string plainTextPassword)
        {
            var salt = GenerateSalt();
            var hash = this.CalculatePasswordHash(plainTextPassword, salt);
            return new PasswordInformation(hash, salt);
        }

        public byte[] CalculatePasswordHash(string plainTextPassword, byte[] passwordSalt)
        {
            var passwordBytes = Encoding.UTF8.GetBytes(plainTextPassword);
            var saltedPassword = passwordSalt.Concat(passwordBytes).ToArray();
            using (var algorithm = new SHA512Managed())
            {
                return algorithm.ComputeHash(saltedPassword);
            }
        }

        private static byte[] GenerateSalt()
        {
            var saltBuffer = new byte[SaltSize];
            using (var generator = new RNGCryptoServiceProvider())
            {
                generator.GetBytes(saltBuffer);
            }

            return saltBuffer;
        }
    }
}
