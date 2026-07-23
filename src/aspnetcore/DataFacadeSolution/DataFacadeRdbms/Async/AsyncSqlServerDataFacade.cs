// ************************************************************************
// Copyright (c) 2026 AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace DataFacadeRdbms.Async
{
    public sealed class AsyncSqlServerDataFacade : IAsyncDataFacade
    {
        public void AddParameter(IDbCommand cmd, string param, DbParamType dbParamType, object value)
        {
            SqlCommand sqlCmd = GetSqlCommand(cmd);
            sqlCmd.Parameters.Add(param, GetSqlDbTypeFromDbParamType(dbParamType)).Value = value;
        }

        public void AddParameter(IDbCommand cmd, string param, DbParamType dbParamType, ParameterDirection paramDirection)
        {
            SqlCommand sqlCmd = GetSqlCommand(cmd);
            sqlCmd.Parameters.Add(param, GetSqlDbTypeFromDbParamType(dbParamType)).Direction = paramDirection;
        }

        public void AddParameter(IDbCommand cmd, string param, DbParamType dbParamType, int size, object value)
        {
            SqlCommand sqlCmd = GetSqlCommand(cmd);
            sqlCmd.Parameters.Add(param, GetSqlDbTypeFromDbParamType(dbParamType), size).Value = value;
        }

        public async Task CloseConnectionAsync(IDbConnection conn)
        {
            if (conn != null && conn.State != ConnectionState.Closed)
            {
                await ((DbConnection)conn).CloseAsync().ConfigureAwait(false);
            }
        }

        public async Task<int> ExecuteNonQueryAsync(IDbCommand cmd)
        {
            return await GetSqlCommand(cmd).ExecuteNonQueryAsync().ConfigureAwait(false);
        }

        public async Task<IDataReader> ExecuteReaderAsync(IDbCommand cmd)
        {
            return await ExecuteReaderAsync(cmd, CommandBehavior.Default).ConfigureAwait(false);
        }

        public async Task<IDataReader> ExecuteReaderAsync(IDbCommand cmd, CommandBehavior cmdBehavior)
        {
            return await GetSqlCommand(cmd).ExecuteReaderAsync(cmdBehavior).ConfigureAwait(false);
        }

        public async Task<object?> ExecuteScalarAsync(IDbCommand cmd)
        {
            return await GetSqlCommand(cmd).ExecuteScalarAsync().ConfigureAwait(false);
        }

        public IDbCommand GetDbCommand(string commandText, IDbConnection conn)
        {
            return new SqlCommand(commandText, GetSqlConnection(conn));
        }

        public IDbCommand GetDbCommandAsync(string commandText, IDbConnection conn, IDbTransaction tran)
        {
            return new SqlCommand(commandText, GetSqlConnection(conn), GetSqlTransaction(tran));
        }

        public IDbConnection GetDbConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }

        public object? SafeConvertFromDBNull(IDataReader reader, string columnName)
        {
            return DBNull.Value.Equals(reader[columnName]) ? null : reader[columnName];
        }

        private static SqlConnection GetSqlConnection(IDbConnection conn)
        {
            return conn as SqlConnection
                ?? throw new ArgumentException("The connection must be a SqlConnection.", nameof(conn));
        }

        private static SqlTransaction GetSqlTransaction(IDbTransaction tran)
        {
            return tran as SqlTransaction
                ?? throw new ArgumentException("The transaction must be a SqlTransaction.", nameof(tran));
        }

        private static SqlCommand GetSqlCommand(IDbCommand cmd)
        {
            return cmd as SqlCommand
                ?? throw new ArgumentException("The command must be a SqlCommand.", nameof(cmd));
        }

        private static SqlDbType GetSqlDbTypeFromDbParamType(DbParamType type)
        {
            return type switch
            {
                DbParamType.String => SqlDbType.VarChar,
                DbParamType.UnicodeString => SqlDbType.NVarChar,
                DbParamType.DateTime => SqlDbType.DateTime,
                DbParamType.Date => SqlDbType.Date,
                DbParamType.Time => SqlDbType.Time,
                DbParamType.Int16 => SqlDbType.TinyInt,
                DbParamType.Int32 => SqlDbType.Int,
                DbParamType.Int64 => SqlDbType.BigInt,
                DbParamType.Decimal => SqlDbType.Decimal,
                DbParamType.Boolean => SqlDbType.Bit,
                _ => throw new ArgumentException("Invalid Db Param type.", nameof(type))
            };
        }

        public async Task<IDbTransaction> GetTransactionAsync(IDbConnection conn)
        {
           return await GetSqlConnection(conn).BeginTransactionAsync().ConfigureAwait(false);
        }
    }
}
