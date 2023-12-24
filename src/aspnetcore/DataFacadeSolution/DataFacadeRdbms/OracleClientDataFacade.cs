using System.Data;
using System.Data.Common;
using System.Data.OracleClient;

namespace DataFacadeRdbms
{
    public sealed class OracleClientDataFacade: IDataFacade
    {
        #region Public Methods
        public IDbConnection GetDbConnection(string connectionString)
        {
            return new OracleConnection(connectionString);
        }

        public IDbTransaction GetTransaction(IDbConnection conn)
        {
            return conn.BeginTransaction();
        }

        public void CloseConnection(IDbConnection conn)
        {
            if (conn != null && conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        public IDbCommand GetDbCommand(string commandText, IDbConnection conn)
        {
            return new OracleCommand(commandText, conn as OracleConnection);
        }

        public IDbCommand GetDbCommand(string commandText, IDbConnection conn, IDbTransaction tran)
        {
            return new OracleCommand(commandText, (OracleConnection)conn, (OracleTransaction)tran);
        }

        public void AddParameter(IDbCommand cmd, string param, DbParamType dbParamType, object value)
        {
            DbCommand dbCmd = (DbCommand)cmd;

            OracleCommand oracleCmd = dbCmd as OracleCommand;

            oracleCmd.Parameters.Add(param, GetOracleDbTypeFromDbParamType(dbParamType)).Value = value;
        }

        public void AddParameter(IDbCommand cmd, string param, DbParamType dbParamType, int size, object value)
        {
            DbCommand dbCmd = (DbCommand)cmd;

            OracleCommand oracleCmd = dbCmd as OracleCommand;

            oracleCmd.Parameters.Add(param, GetOracleDbTypeFromDbParamType(dbParamType), size).Value = value;
        }

        public void AddParameter(IDbCommand cmd, string param, DbParamType dbParamType, ParameterDirection paramDirection)
        {
            DbCommand dbCmd = (DbCommand)cmd;

            OracleCommand oracleCmd = dbCmd as OracleCommand;

            OracleType oracleType = GetOracleDbTypeFromDbParamType(dbParamType);

            oracleCmd.Parameters.Add(param, oracleType).Direction = paramDirection;
        }

        public int ExecuteNonQuery(IDbCommand cmd)
        {
            return cmd.ExecuteNonQuery();
        }

        public IDataReader ExecuteReader(IDbCommand cmd)
        {
            return ExecuteReader(cmd, CommandBehavior.Default);
        }

        public IDataReader ExecuteReader(IDbCommand cmd, CommandBehavior cmdBehavior)
        {
            return cmd.ExecuteReader(cmdBehavior);
        }

        public object ExecuteScalar(IDbCommand cmd)
        {
            return cmd.ExecuteScalar();
        }

        public void CloseDbConnection(IDbConnection connection)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public object SafeConvertFromDBNull(IDataReader reader, string columnName)
        {
            return DBNull.Value.Equals(reader[columnName]) ? null : reader[columnName];
        }
        #endregion

        #region Private Methods
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
