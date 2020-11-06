// <copyright file="PersistenceProvider.cs" company="LukaszNowakowski.it">
// Copyright (c) LukaszNowakowski.it. All rights reserved
// </copyright>
namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.DbConnector.Autofac
{
    using System;

    using global::Autofac;

    /// <summary>
    /// Autofac implementation of <see cref="IPersistenceProvider" />.
    /// </summary>
    public class PersistenceProvider : IPersistenceProvider
    {
        /// <summary>
        /// Lifetime scope to use with this instance.
        /// </summary>
        private readonly ILifetimeScope lifetimeScope;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersistenceProvider" /> class.
        /// </summary>
        /// <param name="lifetimeScope">Lifetime scope to use with this instance.</param>
        public PersistenceProvider(ILifetimeScope lifetimeScope)
        {
            this.lifetimeScope = lifetimeScope ?? throw new ArgumentNullException(nameof(lifetimeScope));
        }

        /// <summary>
        /// Creates persistence.
        /// </summary>
        /// <param name="persistenceKey">Identification of persistence.</param>
        /// <returns><see cref="IPersistence" /> instance created.</returns>
        public IPersistence Create(string persistenceKey)
        {
            return this.lifetimeScope.ResolveNamed<IPersistence>(persistenceKey);
        }
    }
}
