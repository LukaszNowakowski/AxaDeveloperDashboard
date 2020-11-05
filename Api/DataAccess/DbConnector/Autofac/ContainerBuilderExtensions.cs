// <copyright file="ContainerBuilderExtensions.cs" company="LukaszNowakowski.it">
// Copyright (c) LukaszNowakowski.it. All rights reserved
// </copyright>
namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.DbConnector.Autofac
{
    using System;

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
        /// <param name="persistenceFactory">
        /// Factory method for persistence. Input string for the method is a connection
        /// string to use for persistence access.</param>
        /// <returns>Modified container builder.</returns>
        public static ContainerBuilder WithPersistence(
            this ContainerBuilder containerBuilder,
            string name,
            Func<string, IPersistence> persistenceFactory)
        {
            if (persistenceFactory == null)
            {
                throw new ArgumentNullException(nameof(persistenceFactory));
            }

            var persistence = persistenceFactory(name);
            containerBuilder.RegisterInstance(persistence)
                .As<IPersistence>()
                .Named<IPersistence>(name);
            return containerBuilder;
        }
    }
}
