using DotnetCoreSample.Helper.Interface;
using DotnetCoreSample.DataAccessLayer.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model.DataAccessLayer;
using System.Linq;

namespace DotnetCoreSample.Helper{
    public class AccountHelper {
        IAccountProvider _accountProvider;

        public AccountHelper(IAccountProvider accountProvider){
            _accountProvider = accountProvider;
        }

        public async Task<List<M_Account>> GetAllAccounts(){
            var result = await _accountProvider.GetAllAccounts();
            return result.ToList();
        }

        public async Task<M_Account> GetAccountByUserNamePassWord(string userName, string passWord){
            var result = await _accountProvider.GetAccountByUserNamePassWord(userName, passWord);
            return result;
        }
    }
}