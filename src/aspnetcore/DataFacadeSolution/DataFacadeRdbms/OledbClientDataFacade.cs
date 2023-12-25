using System.Data;
using System.Data.Common;
using System.Data.OleDb;

namespace DataFacadeRdbms
{
    /// <inheritdoc />
    public sealed class OledbClientDataFacade : IDataFacade
    {
        #region Public Methods
        /// <inheritdoc />
        public IDbConnection GetDbConnection(string connectionString)
        {
            return new OleDbConnection(connectionString);
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
        public IDbCommand GetDbCommand(string commandText,IDbConnection conn)
        {
            return new OleDbCommand(commandText, (OleDbConnection)conn);
        }

        /// <inheritdoc />
        public IDbCommand GetDbCommand(string commandText, IDbConnection conn, IDbTransaction tran)
        {
            return new OleDbCommand(commandText, (OleDbConnection)conn, (OleDbTransaction)tran);
        }

        /// <inheritdoc />
        public void AddParameter(IDbCommand cmd, string param, DbParamType dbParamType, object value)
        {
            OleDbCommand oleDbCmd = cmd as OleDbCommand;
            OleDbType oleDbType = GetOleDbTypeFromDbParamType(dbParamType);

            oleDbCmd.Parameters.Add(param, oleDbType).Value = value;
        }

        /// <inheritdoc />
        public void AddParameter(IDbCommand cmd, string param, DbParamType dbParamType, int size, object value)
        {
            DbCommand dbCmd = (DbCommand)cmd;

            OleDbCommand oleDbCmd = dbCmd as OleDbCommand;

            OleDbType oleDbType = GetOleDbTypeFromDbParamType(dbParamType);

            oleDbCmd.Parameters.Add(param, oleDbType, size).Value = value;
        }

        /// <inheritdoc />
        public void AddParameter(IDbCommand cmd, string param, DbParamType dbParamType, ParameterDirection paramDirection)
        {
            OleDbCommand oleDbCmd = cmd as OleDbCommand;
            OleDbType oleDbType = GetOleDbTypeFromDbParamType(dbParamType);

            oleDbCmd.Parameters.Add(param, oleDbType).Direction = paramDirection;
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
        public object SafeConvertFromDBNull(IDataReader reader, string columnName)
        {
            return DBNull.Value.Equals(reader[columnName]) ? null : reader[columnName];
        }
        #endregion

        #region Private Methods        
        /// <summary>
        /// Gets the type of the OLE database type from database parameter.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>A datatypes equivalent for given database.</returns>
        /// <exception cref="System.ArgumentException">Invalid Db Param type.</exception>
        private OleDbType GetOleDbTypeFromDbParamType(DbParamType type)
        {
            switch (type)
            {
                case DbParamType.String:
                    return OleDbType.VarChar;

                case DbParamType.DbDate:
                    return OleDbType.DBDate;

                case DbParamType.Date:
                    return OleDbType.Date;

                case DbParamType.DbTime:
                    return OleDbType.DBTime;

                case DbParamType.Int16:
                    return OleDbType.SmallInt;

                case DbParamType.Int32:
                    return OleDbType.Integer;

                case DbParamType.Int64:
                    return OleDbType.BigInt;

                case DbParamType.Decimal:
                    return OleDbType.Decimal;

                default:
                    throw new ArgumentException("Invalid Db Param type.");
            }
        }
        #endregion
    }
}
