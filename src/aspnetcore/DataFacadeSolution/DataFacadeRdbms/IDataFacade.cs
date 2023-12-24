using System.Data;

namespace DataFacadeRdbms
{
    /// <summary>
    ///   <br />
    /// </summary>
    public interface IDataFacade
    {
        void CloseConnection(IDbConnection conn);
        IDbTransaction GetTransaction(IDbConnection conn);
        int ExecuteNonQuery(IDbCommand cmd);
        object ExecuteScalar(IDbCommand cmd);
        IDbConnection GetDbConnection(string connectionString);

        IDataReader ExecuteReader(IDbCommand cmd);
        IDataReader ExecuteReader(IDbCommand cmd, CommandBehavior cmdBehavior);
        IDbCommand GetDbCommand(string commandText,IDbConnection conn);
        IDbCommand GetDbCommand(string commandText, IDbConnection conn, IDbTransaction tran);
        void AddParameter(IDbCommand cmd, string param, DbParamType dbParamType, object value);
        void AddParameter(IDbCommand cmd, string param, DbParamType dbParamType, ParameterDirection paramDirection);
        void AddParameter(IDbCommand cmd, string param, DbParamType dbParamType, int size, object value);
        object SafeConvertFromDBNull(IDataReader reader,string columnName);
    }
}
