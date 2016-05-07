using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialData.ServiceCommand;

namespace TrialData
{
    public class TrialService : ITrialService
    {
        private IProviderFactory _providerFactory;

        public TrialService()
        {
            _providerFactory = new ProviderFactory();
        }
        public TrialService(IProviderFactory providerFactory)
        {
            if (providerFactory == null) throw new ArgumentNullException("providerFactory");

            _providerFactory = providerFactory;
        }

        public Contract.Account.Response.GetUserResponse GetUser(Contract.Account.Request.GetUserRequest request)
        {
            return new GetUserServiceCommand(_providerFactory).Execute(request);
        }
    }
}
