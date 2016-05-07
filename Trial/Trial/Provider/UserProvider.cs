using Contract.Account.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using 


using Contract;namespace Trial.Provider
{
    public class UserProvider: ProviderBase<ITrialService>, IUserProvider
    {
         public UserProvider(IProviderFactory factory, string endpointName)
            : base(factory, endpointName)
        {
        }

        public UserProvider(IProviderFactory factory)
            : base(factory)
        {
        }

        public UserProvider(IProviderFactory factory, ITrialService service)
            : base(factory, service)
        {
        }
        public Contract.Account.Record.UserRecord GetAccount(string userName, string password)
        {
            try
            {
                var request = new GetUserRequest()
                {
                    User_Name = userName,
                    User_Pass = password
                };
                var response = CreateInstance().GetUser(request);
                if (response == null)
                {//log
                    return null;
                }
                if (!response.Status.IsSuccessful)
                {
                   //log
                    return null;
                }
                return response.Record;
            }
            catch (Exception ex)
            {
               //log
                return null;
            }
        }
    }
}