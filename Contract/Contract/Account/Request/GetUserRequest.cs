using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Account.Request
{
     [DataContract(Namespace = "http://Trial/GetUserRequest")]
    public class GetUserRequest : IRetrieveRequest
    {

        [DataMember(Name = "User_Pass", Order = 1, IsRequired = true)]
        public string User_Pass { get; set; }

        [DataMember(Name = "User_Name", Order = 1, IsRequired = true)]
        public string User_Name { get; set; }

      
    }
}
