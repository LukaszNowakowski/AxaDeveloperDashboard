// <copyright file="CommandParameter.cs" company="LukaszNowakowski.it">
// Copyright (c) LukaszNowakowski.it. All rights reserved
// </copyright>
namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.DbConnector
{
    using System.Data;

    /// <summary>
    /// Representation of command parameter.
    /// </summary>
    public class CommandParameter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandParameter" /> class.
        /// </summary>
        /// <param name="name">Name of parameter.</param>
        /// <param name="value">Value of parameter.</param>
        /// <param name="parameterType">Parameter type.</param>
        public CommandParameter(string name, object value, DbType? parameterType)
        {
            this.Name = name;
            this.Value = value;
            this.ParameterType = parameterType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandParameter" /> class.
        /// </summary>
        /// <remarks>Uses database type inferred by runtime.</remarks>
        /// <param name="name">Name of parameter.</param>
        /// <param name="value">Value of parameter.</param>
        public CommandParameter(string name, object value)
            : this(name, value, null)
        {
        }

        /// <summary>
        /// Gets parameter name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets parameter value.
        /// </summary>
        public object Value { get; }

        /// <summary>
        /// Gets parameter type.
        /// </summary>
        public DbType? ParameterType { get; }
    }
}
