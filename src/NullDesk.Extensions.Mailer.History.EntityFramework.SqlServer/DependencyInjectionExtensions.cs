﻿using System;
using Microsoft.Extensions.DependencyInjection;
using NullDesk.Extensions.Mailer.History.EntityFramework.SqlServer;

// ReSharper disable once CheckNamespace
namespace NullDesk.Extensions.Mailer.History.EntityFramework
{
    /// <summary>
    ///     Class DependencyInjectionExtensions.
    /// </summary>
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        ///     Adds an EntityFramework mailer history store using the built-in SqlHistoryContext.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="sqlHistorySettings">The SQL history store settings.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddMailerSqlHistory(
            this IServiceCollection services,
            SqlEntityHistoryStoreSettings sqlHistorySettings)

        {
            return services.AddMailerSqlHistory<SqlHistoryContext>(sqlHistorySettings);
        }

        /// <summary>
        ///     Adds an EntityFramework mailer history store for the specified HistoryContext type.
        /// </summary>
        /// <typeparam name="TContext">The type of the history DbContext.</typeparam>
        /// <param name="services">The services.</param>
        /// <param name="sqlHistorySettings">The SQL history store settings.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddMailerSqlHistory<TContext>(
            this IServiceCollection services,
            SqlEntityHistoryStoreSettings sqlHistorySettings)
            where TContext : SqlHistoryContext
        {
            //implicit conversion
            return services.AddMailerHistory<TContext>(sqlHistorySettings);
        }

        /// <summary>
        ///     Adds an EntityFramework mailer history store for the built-in SqlHistoryContext.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="sqlHistorySettings">The SQL history store settings.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddMailerSqlHistory(
            this IServiceCollection services,
            Action<SqlEntityHistoryStoreSettings> sqlHistorySettings)
        {
            var settings = new SqlEntityHistoryStoreSettings();
            sqlHistorySettings(settings);

            //implicit conversion
            return services.AddMailerSqlHistory<SqlHistoryContext>(settings);
        }

        /// <summary>
        ///     Adds an EntityFramework mailer history store for the specified HistoryContext type.
        /// </summary>
        /// <typeparam name="TContext">The type of the history DbContext.</typeparam>
        /// <param name="services">The services.</param>
        /// <param name="sqlHistorySettings">The SQL history store settings.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddMailerSqlHistory<TContext>(
            this IServiceCollection services,
            Action<SqlEntityHistoryStoreSettings> sqlHistorySettings)
            where TContext : SqlHistoryContext
        {
            var settings = new SqlEntityHistoryStoreSettings();
            sqlHistorySettings(settings);

            //implicit conversion
            return services.AddMailerHistory<TContext>(settings);
        }

        /// <summary>
        ///     Adds a mailer history store of the built-in SqlHistoryContext.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="sqlHistorySettings">Function to obtain sql history settings.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddMailerSqlHistory(
            this IServiceCollection services,
            Func<IServiceProvider, SqlEntityHistoryStoreSettings> sqlHistorySettings)
        {
            return services.AddMailerSqlHistory<SqlHistoryContext>(sqlHistorySettings);
        }

        /// <summary>
        ///     Adds a mailer history store of the specified HistoryContext.
        /// </summary>
        /// <typeparam name="TContext">The type of the t context.</typeparam>
        /// <param name="services">The services.</param>
        /// <param name="sqlHistorySettings">Function to obtain sql history settings.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddMailerSqlHistory<TContext>(
            this IServiceCollection services,
            Func<IServiceProvider, SqlEntityHistoryStoreSettings> sqlHistorySettings)
            where TContext : HistoryContext
        {
            return services.AddMailerHistory<TContext>(s => sqlHistorySettings(s));
        }
    }
}