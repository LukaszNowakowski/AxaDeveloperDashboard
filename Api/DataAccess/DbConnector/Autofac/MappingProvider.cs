// <copyright file="MappingProvider.cs" company="LukaszNowakowski.it">
// Copyright (c) LukaszNowakowski.it. All rights reserved
// </copyright>
namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.DbConnector.Autofac
{
    using System;

    using global::Autofac;

    /// <summary>
    /// Autofac implementation of <see cref="IMappingProvider" />.
    /// </summary>
    public class MappingProvider : IMappingProvider
    {
        /// <summary>
        /// Lifetime scope to use with this instance.
        /// </summary>
        private readonly ILifetimeScope lifetimeScope;

        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProvider" /> class.
        /// </summary>
        /// <param name="lifetimeScope">Lifetime scope to use with this instance.</param>
        public MappingProvider(ILifetimeScope lifetimeScope)
        {
            this.lifetimeScope = lifetimeScope ?? throw new ArgumentNullException(nameof(lifetimeScope));
        }

        /// <summary>
        /// Creates parameters reader.
        /// </summary>
        /// <typeparam name="T">Type to extract parameters from.</typeparam>
        /// <returns><see cref="IParametersReader{T}" /> to use for parameters extraction.</returns>
        public IParametersReader<T> GetParametersReader<T>()
        {
            return this.lifetimeScope.Resolve<IParametersReader<T>>();
        }
    }
}
