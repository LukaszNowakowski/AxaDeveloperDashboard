namespace Avanssur.AxaDeveloperDashboard.Api.Logic.Security.Tokens
{
    public interface ITokenValidator
    {
        TokenData ValidateToken(string token);
    }
}
