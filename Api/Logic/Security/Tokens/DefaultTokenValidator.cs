namespace Avanssur.AxaDeveloperDashboard.Api.Logic.Security.Tokens
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IdentityModel.Tokens.Jwt;
    using System.IO;
    using System.Linq;
    using System.Security.Claims;

    using Avanssur.AxaDeveloperDashboard.Api.Logic.Security.Rsa;

    using Microsoft.IdentityModel.Tokens;

    public class DefaultTokenValidator : ITokenValidator
    {
        private readonly IRsaHandler rsaHandler;

        private readonly Settings settings;

        public DefaultTokenValidator(
            IRsaHandler rsaHandler,
            Settings settings)
        {
            this.rsaHandler = rsaHandler ?? throw new ArgumentNullException(nameof(rsaHandler));
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public TokenData ValidateToken(string token)
        {
            var keyXml = File.ReadAllText(this.settings.PublicKeyFile);
            var securityKey = this.rsaHandler.BuildKey(keyXml);

            var validationParameters = new TokenValidationParameters
            {
                RequireExpirationTime = true,
                RequireSignedTokens = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateLifetime = false,
                IssuerSigningKey = securityKey
            };

            var validator = new JwtSecurityTokenHandler();
            try
            {
                validator.ValidateToken(token, validationParameters, out var validatedToken);
                return ExtractTokenData(validatedToken as JwtSecurityToken);
            }
            catch
            {
                return null;
            }
        }

        private static TokenData ExtractTokenData(JwtSecurityToken token)
        {
            if (token == null)
            {
                return null;
            }

            var userName = token.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value;
            return new TokenData(userName);
        }
    }
}
