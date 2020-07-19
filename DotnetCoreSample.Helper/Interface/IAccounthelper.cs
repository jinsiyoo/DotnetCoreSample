using Model.DataAccessLayer;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotnetCoreSample.Helper.Interface
{
    public interface IAccountHelper
    {
        Task<List<M_Account>> GetAllAccounts();

        Task<M_Account> GetAccountByUserNamePassWord(string userName, string passWord);
    }

}