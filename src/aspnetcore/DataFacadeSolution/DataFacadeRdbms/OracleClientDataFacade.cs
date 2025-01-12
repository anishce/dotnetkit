// ************************************************************************
// Copyright (c) AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

using System.Data;
using System.Data.Common;
using System.Data.OracleClient;

namespace DataFacadeRdbms
{
    /// <inheritdoc />
    public sealed class OracleClientDataFacade : IDataFacade
    {
        #region Public Methods
        /// <inheritdoc />
        public IDbConnection GetDbConnection(string connectionString)
        {
            return new OracleConnection(connectionString);
        }

        /// <inheritdoc />
        public IDbTransaction GetTransaction(IDbConnection conn)
        {
            return conn.BeginTransaction();
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
        public IDbCommand GetDbCommand(string commandText, IDbConnection conn)
        {
            return new OracleCommand(commandText, conn as OracleConnection);
        }

        /// <inheritdoc />
        public IDbCommand GetDbCommand(string commandText, IDbConnection conn, IDbTransaction tran)
        {
            return new OracleCommand(commandText, (OracleConnection)conn, (OracleTransaction)tran);
        }

        /// <inheritdoc />
        public void AddParameter(IDbCommand cmd, string param, DbParamType dbParamType, object value)
        {
            DbCommand dbCmd = (DbCommand)cmd;

            OracleCommand oracleCmd = dbCmd as OracleCommand;

            oracleCmd.Parameters.Add(param, GetOracleDbTypeFromDbParamType(dbParamType)).Value = value;
        }

        /// <inheritdoc />
        public void AddParameter(IDbCommand cmd, string param, DbParamType dbParamType, int size, object value)
        {
            DbCommand dbCmd = (DbCommand)cmd;

            OracleCommand oracleCmd = dbCmd as OracleCommand;

            oracleCmd.Parameters.Add(param, GetOracleDbTypeFromDbParamType(dbParamType), size).Value = value;
        }

        /// <inheritdoc />
        public void AddParameter(IDbCommand cmd, string param, DbParamType dbParamType, ParameterDirection paramDirection)
        {
            DbCommand dbCmd = (DbCommand)cmd;

            OracleCommand oracleCmd = dbCmd as OracleCommand;

            OracleType oracleType = GetOracleDbTypeFromDbParamType(dbParamType);

            oracleCmd.Parameters.Add(param, oracleType).Direction = paramDirection;
        }

        /// <inheritdoc />
        public int ExecuteNonQuery(IDbCommand cmd)
        {
            return cmd.ExecuteNonQuery();
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
        public object ExecuteScalar(IDbCommand cmd)
        {
            return cmd.ExecuteScalar();
        }

        /// <inheritdoc />
        public void CloseDbConnection(IDbConnection connection)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        /// <inheritdoc />
        public object SafeConvertFromDBNull(IDataReader reader, string columnName)
        {
            return DBNull.Value.Equals(reader[columnName]) ? null : reader[columnName];
        }
        #endregion

        #region Private Methods        
        /// <summary>
        /// Gets the type of the oracle database type from database parameter.
        /// </summary>
        /// <param name="dbParamType">Type of the database parameter.</param>
        /// <returns>A datatypes equivalent for given database.</returns>
        /// <exception cref="System.ArgumentException">Invalid Db tyep.</exception>
        private OracleType GetOracleDbTypeFromDbParamType(DbParamType dbParamType)
        {

            switch (dbParamType)
            {
                case DbParamType.AnsiString:
                case DbParamType.AnsiStringFixedLength:
                case DbParamType.String:
                case DbParamType.StringFixedLength:
                    return OracleType.VarChar;

                case DbParamType.Byte:
                    return OracleType.Byte;

                case DbParamType.DateTime:
                    return OracleType.DateTime;

                case DbParamType.Float:
                    return OracleType.Float;

                case DbParamType.Double:
                    return OracleType.Double;

                case DbParamType.Int16:
                    return OracleType.Int16;

                case DbParamType.Int32:
                    return OracleType.Int32;

                default:
                    throw new ArgumentException("Invalid Db tyep.");
            }
        }
        #endregion
    }
}
