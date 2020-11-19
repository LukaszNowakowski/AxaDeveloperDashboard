namespace Avanssur.AxaDeveloperDashboard.Api.Logic.Security.Tokens
{
    public interface ITokenGenerator
    {
        string Create(TokenData token);
    }
}
