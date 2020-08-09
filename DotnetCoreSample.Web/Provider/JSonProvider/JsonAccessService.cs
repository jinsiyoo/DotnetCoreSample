using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Dapper;
using DotnetCoreSample.Web.Provider.Interface;

namespace DotnetCoreSample.Web.Provider.SqlProvider
{
    public abstract class JsonAccessService<T> : IDataAccessService<T>
    {        
		/// <summary>
		/// 檔案路徑
		/// </summary>
        private string _jsonFilePath = string.Empty;

		/// <summary>
		/// 全域的檔案路徑
		/// </summary>
		/// <value></value>
        public string JsonFilePath { get { return _jsonFilePath; } }

        public JsonAccessService(string jsonFilePath){
            _jsonFilePath = jsonFilePath;
        }

		public IEnumerable<T> Query(string sql ,object param = null, CommandType command = CommandType.Text){
			return null;
		}

        public T QueryFirstOrDefault(string sql ,object param = null, CommandType command = CommandType.Text)
        {
            return default(T);
        } 
    }
}