namespace Avanssur.AxaDeveloperDashboard.Api.Logic.Security
{
    using Autofac;
    using Avanssur.AxaDeveloperDashboard.Api.Logic.Security;
    using Microsoft.Extensions.Configuration;

    public class SecurityModule : Module
    {
        private readonly IConfiguration configuration;

        public SecurityModule(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<DefaultSecurityService>()
                .As<ISecurityService>();
            builder.RegisterType<DefaultCryptographyProvider>()
                .As<ICryptographyProvider>();
            builder.RegisterModule(new Tokens.TokensServerModule(this.configuration));
        }
    }
}
