namespace Avanssur.AxaDeveloperDashboard.Api.Logic.Security.Tokens
{
    using System;
    
    using Autofac;

    using Microsoft.Extensions.Configuration;

    public class TokensServerModule : Module
    {
        private readonly IConfiguration configuration;

        public TokensServerModule(IConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.RegisterType<DefaultTokenGenerator>().As<ITokenGenerator>();
            builder.RegisterModule<Rsa.RsaModule>();
            var settings = new Settings();
            this.configuration.Bind("Tokens.Server", settings);
            builder.RegisterInstance(settings);
        }
    }
}
