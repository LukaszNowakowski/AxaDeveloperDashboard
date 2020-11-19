namespace Avanssur.AxaDeveloperDashboard.Api.Logic.Security.Rsa
{
    using Microsoft.IdentityModel.Tokens;

    public interface IRsaHandler
    {
        RsaSecurityKey BuildKey(string xmlWithKey);
    }
}
