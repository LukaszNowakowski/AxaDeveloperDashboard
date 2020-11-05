// <copyright file="PersistenceBase.cs" company="LukaszNowakowski.it">
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
    /// Base class for relational database persistence implementations.
    /// </summary>
    public abstract class PersistenceBase : IPersistence
    {
        /// <summary>
        /// Connection string to use with this instance.
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersistenceBase" /> class.
        /// </summary>
        /// <param name="connectionString">Connection string to use with this instance.</param>
        protected PersistenceBase(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Executes operation on persistence.
        /// </summary>
        /// <param name="commandName">Name of stored procedure.</param>
        /// <param name="parameters">Enumeration of command parameters.</param>
        /// <param name="commandModifier">Delegate allowing to update command properties just before calling persistence.</param>
        /// <param name="cancellationToken">Cancellation token for operation.</param>
        /// <returns>Result code returned by persistence.</returns>
        public async Task ExecuteOperationAsync(
            string commandName,
            IEnumerable<CommandParameter> parameters,
            Action<DbCommand> commandModifier,
            CancellationToken cancellationToken)
        {
            await this.ExecuteDatabaseOperationAsync(
                commandName,
                parameters,
                commandModifier,
                async command =>
                {
                    await command.ExecuteNonQueryAsync(cancellationToken)
                        .ConfigureAwait(false);
                    return true;
                },
                cancellationToken)
                .ConfigureAwait(false);
        }

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
        public async Task<Collection<TResult>> RetrieveDataAsync<TResult>(
            string commandName,
            IEnumerable<CommandParameter> parameters,
            Func<IDataRecord, TResult> rowParser,
            Action<DbCommand> commandModifier,
            CancellationToken cancellationToken)
        {
            return await this.ExecuteDatabaseOperationAsync(
                    commandName,
                    parameters,
                    commandModifier,
                    async command =>
                    {
                        var reader = await command.ExecuteReaderAsync(cancellationToken)
                            .ConfigureAwait(false);
                        var result = new Collection<TResult>();
                        while (reader.Read())
                        {
                            var current = rowParser(reader);
                            result.Add(current);
                        }

                        return result;
                    },
                    cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a database connection for specific engine.
        /// </summary>
        /// <returns>Database connection created.</returns>
        protected abstract DbConnection CreateConnection();

        /// <summary>
        /// Create a database command parameter for specific engine.
        /// </summary>
        /// <returns>Database command parameter created.</returns>
        protected abstract DbParameter CreateParameter();

        /// <summary>
        /// Attaches input parameters to command.
        /// </summary>
        /// <param name="command">Command to attach parameters to.</param>
        /// <param name="parameters">Input parameters.</param>
        private void AttachParameters(DbCommand command, IEnumerable<CommandParameter> parameters)
        {
            foreach (var commandParameter in parameters)
            {
                this.AttachParameter(command, commandParameter, ParameterDirection.Input);
            }
        }

        /// <summary>
        /// Attaches database parameter to command.
        /// </summary>
        /// <param name="command">Command to attach parameter to.</param>
        /// <param name="parameter">Parameter information to attach.</param>
        /// <param name="direction">Parameter direction to set.</param>
        private void AttachParameter(DbCommand command, CommandParameter parameter, ParameterDirection direction)
        {
            var dbParameter = this.CreateParameter();
            dbParameter.ParameterName = parameter.Name;
            dbParameter.Value = parameter.Value;
            if (parameter.ParameterType.HasValue)
            {
                dbParameter.DbType = parameter.ParameterType.Value;
            }

            dbParameter.Direction = direction;
            command.Parameters.Add(dbParameter);
        }

        /// <summary>
        /// Executes database operation.
        /// </summary>
        /// <typeparam name="T">Operation result type.</typeparam>
        /// <param name="commandName">Name of command.</param>
        /// <param name="parameters">Enumeration of parameters.</param>
        /// <param name="commandModifier">Delegate allowing to update command properties just before calling persistence.</param>
        /// <param name="databaseOperation">Operation to perform.</param>
        /// <param name="cancellationToken">Cancellation token for operation.</param>
        /// <returns>Result of operation.</returns>
        private async Task<T> ExecuteDatabaseOperationAsync<T>(
            string commandName,
            IEnumerable<CommandParameter> parameters,
            Action<DbCommand> commandModifier,
            Func<DbCommand, Task<T>> databaseOperation,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(commandName))
            {
                throw new ArgumentNullException(nameof(commandName));
            }

            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using (var connection = this.CreateConnection())
            {
                connection.ConnectionString = this.connectionString;
                using (var command = connection.CreateCommand())
                {
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
                    command.CommandText = commandName;
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
                    command.CommandType = CommandType.StoredProcedure;
                    this.AttachParameters(command, parameters);
                    commandModifier?.Invoke(command);
                    if (connection.State != ConnectionState.Open)
                    {
                        await connection.OpenAsync(cancellationToken)
                            .ConfigureAwait(false);
                    }

                    return await databaseOperation.Invoke(command)
                        .ConfigureAwait(false);
                }
            }
        }
    }
}
