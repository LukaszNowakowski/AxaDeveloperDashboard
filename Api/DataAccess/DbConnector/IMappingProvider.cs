// <copyright file="IMappingProvider.cs" company="LukaszNowakowski.it">
// Copyright (c) LukaszNowakowski.it. All rights reserved
// </copyright>
namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.DbConnector
{
    /// <summary>
    /// Interface for mapping providing services.
    /// </summary>
    public interface IMappingProvider
    {
        /// <summary>
        /// Creates parameters reader.
        /// </summary>
        /// <typeparam name="T">Type to extract parameters from.</typeparam>
        /// <returns><see cref="IParametersReader{T}" /> to use for parameters extraction.</returns>
        IParametersReader<T> GetParametersReader<T>();
    }
}
