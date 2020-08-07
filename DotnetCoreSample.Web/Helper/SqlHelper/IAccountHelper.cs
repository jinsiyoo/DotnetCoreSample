using System.Collections.Generic;
using DotnetCoreSample.Web.Models;

namespace DotnetCoreSample.Web.Helper
{
    public interface IAccountHelper
    {
         List<M_Account> GetAllAccounts();

		M_Account GetAccountByUserNamePassWord(string userName, string passWord);
    }
}