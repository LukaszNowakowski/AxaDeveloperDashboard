// <copyright file="IPersistenceProvider.cs" company="LukaszNowakowski.it">
// Copyright (c) LukaszNowakowski.it. All rights reserved
// </copyright>
namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.DbConnector
{
    /// <summary>
    /// Interface for services providing <see cref="IPersistence" /> implementations.
    /// </summary>
    public interface IPersistenceProvider
    {
        /// <summary>
        /// Creates persistence.
        /// </summary>
        /// <param name="persistenceKey">Identification of persistence.</param>
        /// <returns><see cref="IPersistence" /> instance created.</returns>
        IPersistence Create(string persistenceKey);
    }
}
