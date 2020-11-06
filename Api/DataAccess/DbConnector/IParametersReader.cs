// <copyright file="IParametersReader.cs" company="LukaszNowakowski.it">
// Copyright (c) LukaszNowakowski.it. All rights reserved
// </copyright>
namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.DbConnector
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for parameter readers.
    /// </summary>
    /// <typeparam name="T">Parameters type.</typeparam>
    public interface IParametersReader<in T>
    {
        /// <summary>
        /// Extracts <see cref="CommandParameter" />s enumeration from <typeparamref name="T" /> instance.
        /// </summary>
        /// <param name="input">Parameters instance.</param>
        /// <returns>Command parameters extracted.</returns>
        IEnumerable<CommandParameter> Read(T input);
    }
}
