namespace Avanssur.AxaDeveloperDashboard.Api.Logic.Security
{
    using Autofac;

    public class SecurityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<DefaultSecurityService>()
                .As<ISecurityService>();
        }
    }
}
