namespace Avanssur.AxaDeveloperDashboard.Api.Logic.EnvironmentsManagement
{
    using Autofac;
    using Avanssur.AxaDeveloperDashboard.Api.Logic.Security;

    public class SecurityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<EnvironmentsService>()
                .As<IEnvironmentsService>();
            builder.RegisterType<DefaultCryptographyProvider>()
                .As<ICryptographyProvider>();
        }
    }
}
