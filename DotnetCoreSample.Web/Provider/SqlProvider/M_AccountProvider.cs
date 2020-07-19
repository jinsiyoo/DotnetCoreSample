using DotnetCoreSample.DataAccessLayer.Interface;
using System.Collections.Generic;
using System.Data;
using Model.DataAccessLayer;
using Dapper;
using System.Threading.Tasks;
using DotnetCore.Platform.DataAccess;
using DotnetCoreSample;

namespace DotnetCoreSample.DataAccessLayer
{

    public class AccountProvider : IAccountProvider
    {
        private static string _connectionStr = "Persist Security Info=False;User ID=gitech;Password=apple1;Initial Catalog=DotnetCoreSample;Server=vm052";
        private readonly SqlAccessService _dataAccessService = new SqlAccessService(_connectionStr);

        public IEnumerable<M_Account>> GetAllAccounts()
        {
            string sqlCommand = @"
                SELECT Id, UserName, PassWord, Email, AccountGroup
                FROM M_Account;
            ";

            return _dataAccessService.Q<M_Account>(sqlCommand);
        }

        public async Task<IEnumerable<M_Account>> GetAllAccounts()
        {
            string sqlCommand = @"
                SELECT Id, UserName, PassWord, Email, AccountGroup
                FROM M_Account;
            ";

            return await _dataAccessService.QueryAsync<M_Account>(sqlCommand);
        }

        public async Task<M_Account> GetAccountByUserNamePassWord(string userName, string passWord)
        {
            var parm = new DynamicParameters();
            parm.Add("userName", userName, DbType.AnsiString, size: 20);
            parm.Add("passWord", passWord, DbType.AnsiString, size: 40);

            string sqlCommand = @"
                SELECT Id, UserName, PassWord, Email, AccountGroup
                FROM M_Account
                WHERE UserName = @userName AND PassWord = @passWord;
            ";
            return await _dataAccessService.QueryFirstOrDefaultAsync<M_Account>(sqlCommand, parm);
        }
    }
}

