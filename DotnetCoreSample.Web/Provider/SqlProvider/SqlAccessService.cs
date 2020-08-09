using System.Threading.Tasks;
using System.Data;
using System.Collections.Generic;
using Dapper;
using DotnetCoreSample.Web.Provider.Interface;
using StackExchange.Profiling;
using StackExchange.Profiling.Data;
using System.Data.SqlClient;
using Microsoft.Data.Sqlite;

namespace DotnetCoreSample.Web.Provider.SqlProvider
{
    public abstract class SqlAccessService<T> : IDataAccessService<T>, ISqlRead<T>, ISqlWrite
    {
        /// <summary>
        /// 連線字串
        /// </summary>
        private string _connectionStr = string.Empty;

        /// <summary>
        /// 全域的資料庫連線字串
        /// </summary>
        /// <value></value>
        public string ConnectionStr { get { return _connectionStr; } }

        /// <summary>
        /// 逾時長度（分鐘）
        /// </summary>
        private int _connectionTimeout = 20;

        /// <summary>
        /// 是否啟用 Miniprofiler 觀察套件
        /// </summary>
        private bool _enableMiniprofiler = true;

        private DataProviderType _dataProvider = DataProviderType.SqlServer;

        public string DataProvider
        {
            get { return _dataProvider.ToString(); }
            set
            {
                switch (value)
                {
                    case "SqlServer":
                        _dataProvider = DataProviderType.SqlServer;
                        break;
                    case "SQLite":
                        _dataProvider = DataProviderType.SQLite;
                        break;
                    default:
                        break;
                }
            }
        }

        public SqlAccessService(string connectionStr, string dataProvider)
        {
            _connectionStr = connectionStr;
            DataProvider = dataProvider;
        }

        public IEnumerable<T> Query(string sql, object param = null, CommandType commandType = CommandType.Text)
        {
            using (IDbConnection cnn = GetDbConnection(_dataProvider))
            {
                return cnn.Query<T>(sql, param, null, true, _connectionTimeout, commandType);
            }
        }

        public T QueryFirstOrDefault(string querySql, object param = null, CommandType commandType = CommandType.Text)
        {
            using (IDbConnection cnn = GetDbConnection(_dataProvider))
            {
                return cnn.QueryFirstOrDefault(querySql, param, null, _connectionTimeout, commandType);
            }
        }

        public int Insert(string insertSql, object param = null)
        {
            using (IDbConnection cnn = GetDbConnection(_dataProvider))
            {
                return cnn.Execute(insertSql, param, null, _connectionTimeout, CommandType.Text);
            }
        }

        public int Update(string updateSql, object param = null)
        {
            using (IDbConnection cnn = GetDbConnection(_dataProvider))
            {
                return cnn.Execute(updateSql, param, null, _connectionTimeout, CommandType.Text);
            }
        }

        /// <summary>
        /// 建立資料庫連線
        /// </summary>
        /// <returns>資料庫連線</returns>
        private IDbConnection GetDbConnection(DataProviderType providerType)
        {
            IDbConnection dBConnection;

            switch (providerType)
            {
                case DataProviderType.SqlServer:
                        dBConnection = new ProfiledDbConnection(
                            new SqlConnection(_connectionStr), MiniProfiler.Current);
                    break;
                /*
                case DataProviderType.OleDb:
                    dBConnection = new OleDbConnection();
                    break;
                case DataProviderType.Odbc:
                    dBConnection = new OdbcConnection();
                    break;
                case DataProviderType.Oracle:
                    dBConnection = new OracleConnection();
                    break;
                case DatDataProviderTypeaProvider.MySql:
                    dBConnection = new MySqlConnection();
                    break∏
				*/
                case DataProviderType.SQLite:
                    dBConnection = new SqliteConnection(_connectionStr);
                    break;
                default:
                    return null;
            }

            if (dBConnection.State != ConnectionState.Open)
            {
                dBConnection.Open();
            }

            return dBConnection;
        }
    }

    public enum DataProviderType
    {
        SqlServer,
        Oracle,
        OleDb,
        Odbc,
        MySql,
        SQLite
    }
}