namespace Avanssur.AxaDeveloperDashboard.Api.Logic.Security
{
    public interface ICryptographyProvider
    {
        PasswordInformation GeneratePasswordInformation(string plainTextPassword);

        byte[] CalculatePasswordHash(string plainTextPassword, byte[] passwordSalt);
    }
}
