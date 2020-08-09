using System.Collections.Generic;
using System.Data;
using DotnetCoreSample.Web.Models;
using DotnetCoreSample.Web.Provider.Interface;

namespace DotnetCoreSample.Web.Provider.SqlProvider
{

    public class SqlAccountProvider: SqlAccessService<M_Account>, IAccountProvider
    {
		/// <summary>
		/// 連線字串
		/// </summary>
		private static string _connectionStr = "Persist Security Info=False;User ID=gitech;Password=apple1;Initial Catalog=DotnetCoreSample;Server=vm052";

		public SqlAccountProvider() : base(_connectionStr, "SqlServer"){
			
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
            var parm = new { userName = account_id, passWord = account_pwd };

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

