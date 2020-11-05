// <copyright file="IPersistence.cs" company="LukaszNowakowski.it">
// Copyright (c) LukaszNowakowski.it. All rights reserved
// </copyright>
namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.DbConnector
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Data.Common;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface of persistence.
    /// </summary>
    public interface IPersistence
    {
        /// <summary>
        /// Executes operation on persistence.
        /// </summary>
        /// <param name="commandName">Name of stored procedure.</param>
        /// <param name="parameters">Enumeration of command parameters.</param>
        /// <param name="commandModifier">Delegate allowing to update command properties just before calling persistence.</param>
        /// <param name="cancellationToken">Cancellation token for operation.</param>
        /// <returns>Result code returned by persistence.</returns>
        Task ExecuteOperationAsync(
            string commandName,
            IEnumerable<CommandParameter> parameters,
            Action<DbCommand> commandModifier,
            CancellationToken cancellationToken);

        /// <summary>
        /// Executes a procedure retrieving data.
        /// </summary>
        /// <typeparam name="TResult">Type that result row can be mapped to.</typeparam>
        /// <param name="commandName">Name of stored procedure.</param>
        /// <param name="parameters">Enumeration of command parameters.</param>
        /// <param name="rowParser">Function that parses data row to result instance.</param>
        /// <param name="commandModifier">Delegate allowing to update command properties just before calling persistence.</param>
        /// <param name="cancellationToken">Cancellation token for operation.</param>
        /// <returns>Collection of instances retrieved.</returns>
        Task<Collection<TResult>> RetrieveDataAsync<TResult>(
            string commandName,
            IEnumerable<CommandParameter> parameters,
            Func<IDataRecord, TResult> rowParser,
            Action<DbCommand> commandModifier,
            CancellationToken cancellationToken);
    }
}
