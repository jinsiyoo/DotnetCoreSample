using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Dapper;
using DotnetCoreSample.Web.Provider;
using StackExchange.Profiling;
using StackExchange.Profiling.Data;

namespace DotnetCoreSample.Web.Provider.SqlProvider
{
    public abstract class SqlAccessService<T> : IDataAccessService<T>, ISqlProvider<T>
    {        
		/// <summary>
		/// 連線字串
		/// </summary>
        private string _connectionStr = string.Empty;

		/// <summary>
		/// 全域的資料庫連線字串
		/// </summary>
		/// <value></value>
        public string connectionStr { get { return _connectionStr; } }

		/// <summary>
		/// 逾時長度（分鐘）
		/// </summary>
        private int _connectionTimeout = 20;

		/// <summary>
		/// 是否啟用 Miniprofiler 觀察套件
		/// </summary>
		private bool _enableMiniprofiler = true;

        public SqlAccessService(string connectionStr){
            _connectionStr = connectionStr;
        }

		/// <summary>
		/// 資料查詢
		/// </summary>
		/// <param name="querySql">SQL敘述</param>
		/// <param name="param">查詢參數物件</param>
		/// <param name="commandType">敘述類型</param>
		public IEnumerable<T> Query(string sql, object param = null, CommandType commandType = CommandType.Text){
			using (IDbConnection cnn = GetDbConnection())
            {
                return cnn.Query<T>(sql, param, null, true, _connectionTimeout, commandType);
            }
		}

        public T QueryFirstOrDefault(string querySql, object param = null, CommandType commandType = CommandType.Text)
        {
            using (IDbConnection cnn = GetDbConnection())
            {
                return cnn.QueryFirstOrDefault(querySql, param, null, _connectionTimeout, commandType);
            }
        }

        /// <summary>
        /// 建立資料庫連線
        /// </summary>
        /// <returns>資料庫連線</returns>
        private IDbConnection GetDbConnection()
        {
            IDbConnection dBConnection;

            if (!_enableMiniprofiler)
            {
                dBConnection = new SqlConnection(_connectionStr);
            }
            else
            {
                dBConnection = new ProfiledDbConnection(
                    new SqlConnection(_connectionStr), MiniProfiler.Current);
            }

            if (dBConnection.State != ConnectionState.Open)
            {
                dBConnection.Open();
            }

            return dBConnection;
        }
    }
}