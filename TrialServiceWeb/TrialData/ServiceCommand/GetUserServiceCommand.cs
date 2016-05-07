using Contract;
using Contract.Account.Record;
using Contract.Account.Request;
using Contract.Account.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialData.ServiceCommand
{
    public class GetUserServiceCommand : ProviderCommand<IProviderFactory, GetUserRequest, GetUserResponse>
    {
        public GetUserServiceCommand(IProviderFactory providers)
            : base(providers)
        {

        }
        private string userName;
        private string password;
        protected override bool OnExecute(GetUserResponse response)
        {
            response.Status = new ResponseStatus() { IsSuccessful = false };
            try
            {
                var userModel = Providers.Data.User.Find(x => x.User_Name == userName && x.User_Pass == password);
                UserRecord record = new UserRecord()
                {
                    User_Id = userModel.User_Id,
                    User_Name = userModel.User_Name,
                    User_Pass = userModel.User_Pass
                };
                if (record != null)
                {
                    response.Status.IsSuccessful = true;
                    response.Record = record;
                }
               
            }
            catch (Exception)
            {

                throw;
            }
            return response.Status.IsSuccessful;
        }

        protected override void Validate(GetUserRequest request)
        {
            if (request == null)
                throw new Exception("request is null");
            if (string.IsNullOrEmpty(request.User_Name))
                throw new Exception("User name is null");
            if (string.IsNullOrEmpty(request.User_Pass))
                throw new Exception("user password is null");
            userName = request.User_Name;
            password = request.User_Pass;

        }
    }
}
