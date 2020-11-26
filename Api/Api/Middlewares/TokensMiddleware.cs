namespace Avanssur.AxaDeveloperDashboard.Api.Middlewares
{
    using System;
    using System.Threading.Tasks;
    using Avanssur.AxaDeveloperDashboard.Api.Logic.Security.Tokens;
    using Microsoft.AspNetCore.Http;

    public class TokensMiddleware
    {
        private readonly RequestDelegate next;

        private readonly ITokenValidator tokenValidator;

        public TokensMiddleware(RequestDelegate next, ITokenValidator tokenValidator)
        {
            this.next = next;
            this.tokenValidator = tokenValidator ?? throw new ArgumentNullException(nameof(tokenValidator));
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Headers.TryGetValue("AxaDashboard-AuthenticationToken", out var tokenValues))
            {
                if (tokenValues.Count == 1)
                {
                    await this.HandleToken(context, tokenValues[0]);
                }
            }

            if (this.next == null)
            {
                return;
            }

            await this.next.Invoke(context);
        }

        private Task HandleToken(HttpContext context, string token)
        {
            var tokenData = this.tokenValidator.ValidateToken(token);
            if (tokenData != null)
            {
                context.SetTokenData(tokenData);
            }

            return Task.CompletedTask;
        }
    }
}
