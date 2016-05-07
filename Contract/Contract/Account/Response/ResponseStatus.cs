using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Account.Response
{
    [DataContract(Namespace = "http://Trial/ResponseStatus")]
    public class ResponseStatus
    {
        [DataMember(Name = "IsSuccessful", Order = 1, IsRequired = true)]
        public bool IsSuccessful { get; set; }

        [DataMember(Name = "ErrorMessage", Order = 2, IsRequired = false)]
        public string ErrorMessage { get; set; }
    }
}
