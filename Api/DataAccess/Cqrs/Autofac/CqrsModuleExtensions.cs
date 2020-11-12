namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Cqrs.Autofac
{
    using System.Reflection;
    using global::Autofac;

    public static class CqrsModuleExtensions
    {
        public static ContainerBuilder RegisterHandlers(
            this ContainerBuilder builder,
            params Assembly[] assemblies)
        {
            return builder
                .RegisterQueryHandlers(assemblies)
                .RegisterCommandHandlers(assemblies);
        }

        private static ContainerBuilder RegisterQueryHandlers(
            this ContainerBuilder builder,
            params Assembly[] assemblies)
        {
            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => t.IsClosedTypeOf(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces();
            return builder;
        }

        private static ContainerBuilder RegisterCommandHandlers(
            this ContainerBuilder builder,
            params Assembly[] assemblies)
        {
            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => t.IsClosedTypeOf(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces();
            return builder;
        }
    }
}
