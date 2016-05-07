using Contract.Account.Record;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial.Provider
{
    public interface IUserProvider
    {
       UserRecord GetAccount(string userName, string password);
    }
}
