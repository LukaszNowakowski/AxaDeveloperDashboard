namespace Avanssur.AxaDeveloperDashboard.Api.Middlewares
{
    using Microsoft.AspNetCore.Builder;

    public static class TokensMiddlewareExtensions
    {
        public static IApplicationBuilder UseTokensMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TokensMiddleware>();
        }
    }
}
