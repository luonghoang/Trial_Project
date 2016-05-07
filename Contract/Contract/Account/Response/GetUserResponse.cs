using Contract.Account.Record;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Account.Response
{
    [DataContract(Namespace = "http://Trial/GetUserResponse")]
    public class GetUserResponse
    {
        [DataMember(Name = "Status", Order = 1, IsRequired = true)]
        public ResponseStatus Status { get; set; }

        [DataMember(Name = "Record", Order = 2, IsRequired = true)]
        public UserRecord Record { get; set; }
    }
}
