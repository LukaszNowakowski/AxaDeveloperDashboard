namespace Avanssur.AxaDeveloperDashboard.Api.Logic
{
    using Autofac;

    public class LogicModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterModule<EnvironmentsManagement.SecurityModule>();
            builder.RegisterModule<Security.SecurityModule>();
            builder.RegisterModule<DataAccess.DataAccessModule>();
        }
    }
}
