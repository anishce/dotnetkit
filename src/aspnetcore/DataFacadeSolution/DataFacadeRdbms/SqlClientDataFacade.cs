﻿// ************************************************************************
// Copyright (c) 2025 AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DataFacadeRdbms
{
    /// <inheritdoc />
    public sealed class SqlClientDataFacade : IDataFacade
    {
        #region Public Methods

        /// <inheritdoc />
        public IDbConnection GetDbConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }

        /// <inheritdoc />
        public void CloseConnection(IDbConnection conn)
        {
            if (conn != null && conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        /// <inheritdoc />
        public IDbTransaction GetTransaction(IDbConnection conn)
        {
            return conn.BeginTransaction();
        }

        /// <inheritdoc />
        public IDbCommand GetDbCommand(string commandText, IDbConnection conn)
        {
            return new SqlCommand(commandText, (SqlConnection)conn);
        }

        /// <inheritdoc />
        public IDbCommand GetDbCommand(string commandText, IDbConnection conn, IDbTransaction tran)
        {
            return new SqlCommand(commandText, (SqlConnection)conn, (SqlTransaction)tran);
        }

        /// <inheritdoc />
        public void AddParameter(IDbCommand cmd, string param, DbParamType dbParamType, object value)
        {
            DbCommand dbCmd = (DbCommand)cmd;

            SqlCommand sqlCmd = dbCmd as SqlCommand;

            SqlDbType sqlDbType = GetSqlDbTypeFromDbParamType(dbParamType);

            sqlCmd.Parameters.Add(param, sqlDbType).Value = value;
        }

        /// <inheritdoc />
        public void AddParameter(IDbCommand cmd, string param, DbParamType dbParamType, int size, object value)
        {
            DbCommand dbCmd = (DbCommand)cmd;

            SqlCommand sqlCmd = dbCmd as SqlCommand;

            sqlCmd.Parameters.Add(param, GetSqlDbTypeFromDbParamType(dbParamType), size).Value = value;
        }

        /// <inheritdoc />
        public void AddParameter(IDbCommand cmd, string param, DbParamType dbParamType, ParameterDirection paramDirection)
        {
            DbCommand dbCmd = (DbCommand)cmd;

            SqlCommand sqlCmd = dbCmd as SqlCommand;

            SqlDbType sqlDbType = GetSqlDbTypeFromDbParamType(dbParamType);

            sqlCmd.Parameters.Add(param, sqlDbType).Direction = paramDirection;
        }

        /// <inheritdoc />
        public IDataReader ExecuteReader(IDbCommand cmd)
        {
            return ExecuteReader(cmd, CommandBehavior.Default);
        }

        /// <inheritdoc />
        public IDataReader ExecuteReader(IDbCommand cmd, CommandBehavior cmdBehavior)
        {
            return cmd.ExecuteReader(cmdBehavior);
        }

        /// <inheritdoc />
        public int ExecuteNonQuery(IDbCommand cmd)
        {
            return cmd.ExecuteNonQuery();
        }

        /// <inheritdoc />
        public object ExecuteScalar(IDbCommand cmd)
        {
            return cmd.ExecuteScalar();
        }

        /// <inheritdoc />
        public object? SafeConvertFromDBNull(IDataReader reader, string columnName)
        {
            return DBNull.Value.Equals(reader[columnName]) ? null : reader[columnName];
        }
        #endregion

        #region Private Methods        
        /// <summary>
        /// Gets the type of the SQL database type from database parameter.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>A datatypes equivalent for given database.</returns>
        /// <exception cref="System.ArgumentException">Invalid Db Param type.</exception>
        private SqlDbType GetSqlDbTypeFromDbParamType(DbParamType type)
        {
            switch (type)
            {
                case DbParamType.String:
                    return SqlDbType.VarChar;

                case DbParamType.UnicodeString:
                    return SqlDbType.NVarChar;

                case DbParamType.DateTime:
                    return SqlDbType.DateTime;

                case DbParamType.Date:
                    return SqlDbType.Date;

                case DbParamType.Time:
                    return SqlDbType.Time;

                case DbParamType.Int16:
                    return SqlDbType.TinyInt;

                case DbParamType.Int32:
                    return SqlDbType.Int;

                case DbParamType.Int64:
                    return SqlDbType.BigInt;

                case DbParamType.Decimal:
                    return SqlDbType.Decimal;

                case DbParamType.Boolean:
                    return SqlDbType.Bit;

                default:
                    throw new ArgumentException("Invalid Db Param type.");
            }
        }
        #endregion
    }
}
