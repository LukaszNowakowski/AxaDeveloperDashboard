namespace Avanssur.AxaDeveloperDashboard.Api.Logic.Security.Tokens
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IdentityModel.Tokens.Jwt;
    using System.IO;
    using System.Security.Claims;

    using Avanssur.AxaDeveloperDashboard.Api.Logic.Security.Rsa;

    using Microsoft.IdentityModel.Tokens;

    public class DefaultTokenGenerator : ITokenGenerator
    {
        private readonly IRsaHandler rsaHandler;

        private readonly Settings settings;

        public DefaultTokenGenerator(
            IRsaHandler rsaHandler,
            Settings settings)
        {
            this.rsaHandler = rsaHandler ?? throw new ArgumentNullException(nameof(rsaHandler));
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public string Create(TokenData tokenData)
        {
            var token = this.CreateToken(tokenData);
            var tokenHandler = new JwtSecurityTokenHandler();
            var result = tokenHandler.WriteToken(token);
            return result;
        }

        private static IEnumerable<Claim> CreateClaims(TokenData tokenData)
        {
            yield return new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString());
            yield return new Claim(JwtRegisteredClaimNames.Sub, tokenData.UserName);
            yield return new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture));
        }

        private JwtSecurityToken CreateToken(TokenData tokenData)
        {
            var keyXml = File.ReadAllText(this.settings.PrivateKeyFile);
            var securityKey = this.rsaHandler.BuildKey(keyXml);
            var token = new JwtSecurityToken(
                issuer: "AXA_DEVELOPER_DASHBOARD",
                audience: "users",
                claims: CreateClaims(tokenData),
                expires: DateTime.Now.AddDays(15),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.RsaSha256Signature, SecurityAlgorithms.Sha256Digest));
            return token;
        }
    }
}
