namespace Avanssur.AxaDeveloperDashboard.Api
{
    using Avanssur.AxaDeveloperDashboard.Api.Logic.Security.Tokens;
    using Microsoft.AspNetCore.Http;

    public static class HttpContextExtensions
    {
        private const string TokenDataKey = "AxaDashboard_TokenData";

        public static void SetTokenData(this HttpContext context, TokenData tokenData)
        {
            context.Items.Add(TokenDataKey, tokenData);
        }

        public static TokenData GetTokenData(this HttpContext context)
        {
            if (!context.Items.ContainsKey(TokenDataKey))
            {
                return null;
            }

            var tokenData = context.Items[TokenDataKey] as TokenData;
            return tokenData;
        }
    }
}
