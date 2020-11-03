namespace Avanssur.AxaDeveloperDashboard.Api.Logic.EnvironmentsManagement
{
    using Autofac;

    public class EnvironmentsManagementModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<EnvironmentsService>()
                .As<IEnvironmentsService>();
        }
    }
}
