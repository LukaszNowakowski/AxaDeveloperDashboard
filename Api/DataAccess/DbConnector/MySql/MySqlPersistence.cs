// <copyright file="MySqlPersistence.cs" company="LukaszNowakowski.it">
// Copyright (c) LukaszNowakowski.it. All rights reserved
// </copyright>
namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.DbConnector.MySql
{
    using System.Data.Common;

    using global::MySql.Data.MySqlClient;

    /// <summary>
    /// Persistence provider for MySQL database.
    /// </summary>
    public class MySqlPersistence : PersistenceBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MySqlPersistence" /> class.
        /// </summary>
        /// <param name="connectionString">Connection string to use with this instance.</param>
        public MySqlPersistence(string connectionString)
            : base(connectionString)
        {
        }

        /// <summary>
        /// Creates a database connection for specific engine.
        /// </summary>
        /// <returns>Database connection created.</returns>
        protected override DbConnection CreateConnection()
        {
            return new MySqlConnection();
        }

        /// <summary>
        /// Create a database command parameter for specific engine.
        /// </summary>
        /// <returns>Database command parameter created.</returns>
        protected override DbParameter CreateParameter()
        {
            return new MySqlParameter();
        }
    }
}
