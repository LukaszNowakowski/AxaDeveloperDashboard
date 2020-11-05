// <copyright file="DataAccessModule.cs" company="LukaszNowakowski.it">
// Copyright (c) LukaszNowakowski.it. All rights reserved
// </copyright>
namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.DbConnector.Autofac
{
    using global::Autofac;

    /// <summary>
    /// Autofac registrations for data access.
    /// </summary>
    public class DataAccessModule : Module
    {
        /// <summary>
        /// Performs registrations in <see cref="ContainerBuilder" />.
        /// </summary>
        /// <param name="builder">Builder to register to.</param>
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<MappingProvider>()
                .As<IMappingProvider>();
            builder.RegisterType<PersistenceProvider>()
                .As<IPersistenceProvider>();
        }
    }
}
