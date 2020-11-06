// <copyright file="ContainerBuilderExtensions.cs" company="LukaszNowakowski.it">
// Copyright (c) LukaszNowakowski.it. All rights reserved
// </copyright>
namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.DbConnector.Autofac
{
    using System;
    using Avanssur.AxaDeveloperDashboard.Api.DataAccess.DbConnector.MySql;
    using global::Autofac;

    /// <summary>
    /// Extension methods for <see cref="ContainerBuilder" /> class.
    /// </summary>
    public static class ContainerBuilderExtensions
    {
        /// <summary>
        /// Registers <see cref="IPersistence" /> instance.
        /// </summary>
        /// <param name="containerBuilder">Container builder to register to.</param>
        /// <param name="name">Name of persistence.</param>
        /// <param name="connectionStringProvider">Method providing connection string by its name.</param>
        /// <returns>Modified container builder.</returns>
        public static ContainerBuilder WithMySqlPersistence(
            this ContainerBuilder containerBuilder,
            string name,
            Func<string, string> connectionStringProvider)
        {
            if (connectionStringProvider == null)
            {
                throw new ArgumentNullException(nameof(connectionStringProvider));
            }

            var connectionString = connectionStringProvider(name);
            var persistence = new MySqlPersistence(connectionString);
            containerBuilder.RegisterInstance(persistence)
                .As<IPersistence>()
                .Named<IPersistence>(name);
            return containerBuilder;
        }
    }
}
