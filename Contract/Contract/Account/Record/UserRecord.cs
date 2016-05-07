using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Contract.Account.Record
{
    [DataContract(Namespace = "http://Trial/UserRecord")]
    public class UserRecord
    {
        [DataMember(Name = "User_Id", Order = 1, IsRequired = true)]
        public string User_Id { get; set; }

        [DataMember(Name = "User_Pass", Order = 1, IsRequired = true)]
        public string User_Pass { get; set; }

        [DataMember(Name = "User_Name", Order = 1, IsRequired = true)]
        public string User_Name { get; set; }
    }
}
