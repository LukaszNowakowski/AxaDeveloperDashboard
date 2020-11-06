namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess
{
    using Autofac;
    using Avanssur.AxaDeveloperDashboard.Api.DataAccess.Cqrs.Autofac;

    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterModule<CqrsModule>();
            builder.RegisterModule<DbConnector.Autofac.DataAccessModule>();
            builder.RegisterHandlers(typeof(DbConnector.Autofac.DataAccessModule).Assembly);
        }
    }
}
