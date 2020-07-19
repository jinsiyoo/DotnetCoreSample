using System.Threading.Tasks;
using System.Collections.Generic;
using Model.DataAccessLayer;

namespace DotnetCoreSample.DataAccessLayer.Interface
{ 
    public interface IAccountProvider
    {
        Task<IEnumerable<M_Account>> GetAllAccounts();

        Task<M_Account> GetAccountByUserNamePassWord(string userName, string passWord);
    }

}