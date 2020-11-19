namespace Avanssur.AxaDeveloperDashboard.Api.Logic
{
    using Autofac;
    using Microsoft.Extensions.Configuration;

    public class LogicModule : Module
    {
        private readonly IConfiguration configuration;

        public LogicModule(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterModule<EnvironmentsManagement.SecurityModule>();
            builder.RegisterModule(new Security.SecurityModule(this.configuration));
            builder.RegisterModule<DataAccess.DataAccessModule>();
        }
    }
}
