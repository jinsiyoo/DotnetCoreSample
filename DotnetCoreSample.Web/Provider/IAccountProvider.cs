using System.Collections.Generic;
using System.Threading.Tasks;
using DotnetCoreSample.Web.Models;

namespace DotnetCoreSample.Web.Provider
{
	public interface IAccountProvider
    {
        /// <summary>
        /// 取得所有帳戶
        /// </summary>
        /// <returns></returns>

        IEnumerable<M_Account> GetAllAccounts();

        /// <summary>
        /// 透由帳戶名稱與帳戶密碼取得帳戶
        /// </summary>
        /// <param name="account_id">帳戶名稱</param>
        /// <param name="account_pwd">帳戶密碼</param>
        /// <returns></returns>
        M_Account GetAccount(string account_id, string account_pwd);
    }
}
