namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Cqrs.Autofac
{
    using global::Autofac;

    public class CqrsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<Mediator>().As<IMediator>();
            builder.RegisterType<HandlerFactory>().As<IHandlerFactory>();
        }
    }
}
