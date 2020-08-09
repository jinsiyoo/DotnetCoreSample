using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using DotnetCoreSample.Web.Models;
using DotnetCoreSample.Web.Provider.Interface;

namespace DotnetCoreSample.Web.Helper{

    public class AccountHelper : IAccountHelper {
        IAccountProvider _accountProvider;

        public AccountHelper(IAccountProvider accountProvider){
            _accountProvider = accountProvider;
        }

        public List<M_Account> GetAllAccounts(){
            var result = _accountProvider.GetAllAccounts();
            return result.ToList();
        }

        public M_Account GetAccountByUserNamePassWord(string userName, string passWord){
            var result = _accountProvider.GetAccount(userName, passWord);
            return result;
        }
    }
}