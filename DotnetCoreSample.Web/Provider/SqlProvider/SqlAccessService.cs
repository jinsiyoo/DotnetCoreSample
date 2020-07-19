using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Dapper;

namespace DotnetCore.Platform.DataAccess
{
    public abstract class SqlAccessService<T> : IDataAccessService<T>
    {        
        private string _connectionStr = string.Empty;
        public string connectionStr { get { return _connectionStr; } }

        private int _connectionTimeout = 20;

        public SqlAccessService(string connectionStr){
            _connectionStr = connectionStr;
        }

        public async Task<IEnumerable<TReturn>> QueryAsync<TReturn>(string querySql, object param = null, CommandType commandType = CommandType.Text)
        {
            using (IDbConnection con = GetDbConnection())
            {
                return await con.QueryAsync<TReturn>(querySql, param, null, _connectionTimeout, commandType).ConfigureAwait(false);
            }
        }

        public async Task<TResult> QueryFirstOrDefaultAsync<TResult>(string querySql, object param = null, CommandType commandType = CommandType.Text)
        {
            using (IDbConnection con = GetDbConnection())
            {
                return await con.QueryFirstOrDefaultAsync<TResult>(querySql, param, null, _connectionTimeout, commandType).ConfigureAwait(false);
            }
        }

        private IDbConnection GetDbConnection()
        {
            IDbConnection dBConnection;

            dBConnection = new SqlConnection(_connectionStr);

            if (dBConnection.State != ConnectionState.Open)
            {
                dBConnection.Open();
            }

            return dBConnection;
        }
    }
}