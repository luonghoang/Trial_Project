using Contract.Account.Request;
using Contract.Account.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    [ServiceContract(Namespace = "http://Trial/")]
    public interface ITrialService
    {
        [OperationContract(Name = "GetUser")]
        GetUserResponse GetUser(GetUserRequest request);
    }
}
