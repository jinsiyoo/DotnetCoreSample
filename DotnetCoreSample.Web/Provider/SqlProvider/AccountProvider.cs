using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using DotnetCoreSample.Web.Models;
using DotnetCoreSample.Web.Provider;

namespace DotnetCoreSample.Web.Provider.SqlProvider
{

    public class AccountProvider: SqlAccessService<M_Account>, IAccountProvider
    {
		/// <summary>
		/// 連線字串
		/// </summary>
        private static string _connectionStr = "Persist Security Info=False;User ID=gitech;Password=apple1;Initial Catalog=DotnetCoreSample;Server=vm052";

		/// <summary>
		/// 全域連線字串
		/// </summary>
		/// <value>連線字串</value>
		public static string ConnectionStr { get{ return _connectionStr; } }

		public AccountProvider() : base(_connectionStr ){
			
		}

		/// <summary>
		/// 查詢所有用戶資料
		/// </summary>
		/// <returns>用戶物件資料</returns>
        public IEnumerable<M_Account> GetAllAccounts()
        {
            string sqlCommand = @"
                SELECT Id, UserName, PassWord, Email, AccountGroup
                FROM M_Account;
            ";
			return this.Query(sqlCommand);
        }

		/// <summary>
		/// 查詢特定用戶資料（帳號、密碼）
		/// </summary>
		/// <param name="account_id">帳號</param>
		/// <param name="account_pwd">密碼</param>
		/// <returns>用戶物件資料</returns>
        public M_Account GetAccount(string account_id, string account_pwd)
        {
            var parm = new DynamicParameters();
            parm.Add("userName", account_id, DbType.AnsiString, size: 20);
            parm.Add("passWord", account_pwd, DbType.AnsiString, size: 40);

            string sqlCommand = @"
                SELECT Id, UserName, PassWord, Email, AccountGroup
                FROM M_Account
                WHERE UserName = @userName 
				AND PassWord = @passWord;
            ";
            return this.QueryFirstOrDefault(sqlCommand, parm);
        }
    }
}

