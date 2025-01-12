// ************************************************************************
// Copyright (c) AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

using System.Data;

namespace DataFacadeRdbms
{
    /// <summary>
    /// Represents an open & close connection, open data reader, execure data command that access relational databases.
    /// </summary>
    public interface IDataFacade
    {
        /// <summary>
        /// Closes the database connection.
        /// </summary>
        /// <param name="conn">The database connection.</param>
        void CloseConnection(IDbConnection conn);

        /// <summary>
        /// Gets the transaction.
        /// </summary>
        /// <param name="conn">The connection.</param>
        /// <returns></returns>
        IDbTransaction GetTransaction(IDbConnection conn);

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <returns>The number of rows affected.</returns>
        int ExecuteNonQuery(IDbCommand cmd);

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="cmd">The fb command.</param>
        /// <returns>The first column of the first row in the resultset.</returns>
        object ExecuteScalar(IDbCommand cmd);

        /// <summary>
        /// Gets the database connection.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <returns>The database connection.</returns>
        IDbConnection GetDbConnection(string connectionString);

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <returns><see cref="IDataReader"></returns>
        IDataReader ExecuteReader(IDbCommand cmd);

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <param name="cmdBehavior">The command behavior.</param>
        /// <returns><see cref="IDataReader">.</returns>
        IDataReader ExecuteReader(IDbCommand cmd, CommandBehavior cmdBehavior);

        /// <summary>
        /// Gets the database command.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="conn">The connection.</param>
        /// <returns>The database command.</returns>
        IDbCommand GetDbCommand(string commandText, IDbConnection conn);

        /// <summary>
        /// Gets the database command.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="conn">The connection.</param>
        /// <param name="tran">The tran.</param>
        /// <returns>The database command.</returns>
        IDbCommand GetDbCommand(string commandText, IDbConnection conn, IDbTransaction tran);

        /// <summary>
        /// Adds the db parameter.
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <param name="param">The parameter.</param>
        /// <param name="dbParamType">Type of the database parameter.</param>
        /// <param name="value">The value.</param>
        void AddParameter(IDbCommand cmd, string param, DbParamType dbParamType, object value);

        /// <summary>
        /// Adds the db parameter.
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <param name="param">The parameter.</param>
        /// <param name="dbParamType">Type of the database parameter.</param>
        /// <param name="paramDirection">The parameter direction.</param>
        void AddParameter(IDbCommand cmd, string param, DbParamType dbParamType, ParameterDirection paramDirection);

        /// <summary>
        /// Adds the db parameter.
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <param name="param">The parameter.</param>
        /// <param name="dbParamType">Type of the database parameter.</param>
        /// <param name="size">The size.</param>
        /// <param name="value">The value.</param>
        void AddParameter(IDbCommand cmd, string param, DbParamType dbParamType, int size, object value);

        /// <summary>
        /// Safes the convert from database null.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>An object if db column doesn't have null value otherwise null.<returns>
        object? SafeConvertFromDBNull(IDataReader reader, string columnName);
    }
}
