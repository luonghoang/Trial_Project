using Contract.Account.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public abstract class ServiceBases<TRequest, TResponse>
        where TRequest : IRequest
        where TResponse : IResponse, new()
    {
        protected string Caller { get; private set; }

        public TRequest Request { get; private set; }

        protected TResponse Response { get; private set; }
        protected ServiceBases()
        {
            Response = new TResponse();
            Response.Status = new ResponseStatus();
            Response.Status.IsSuccessful = false;
        }

        protected abstract void Validate(TRequest request);

        protected abstract bool OnExecute(TResponse response);

        public virtual TResponse Execute(TRequest request)
        {
            Request = request;
            try
            {
                this.Validate(request);

                bool executeResult = this.OnExecute(Response);

                Response.Status.IsSuccessful = executeResult;
            }
            catch (Exception ex)
            {
               
            }
            return Response;
        }

    }

    public interface IRequest
    {
       
    }
    public interface IResponse
    {
        ResponseStatus Status { get; set; }
    }

    public abstract class ProviderCommand<TFactory, TRequest, TResponse> : ServiceBases<TRequest, TResponse>
        where TFactory : IProviderFactoryBase
        where TRequest : IRequest
        where TResponse : IResponse, new()
    {
        protected TFactory Providers { get; private set; }

        public ProviderCommand(TFactory providerFactory)
            : base()
        {
            if (providerFactory == null) throw new ArgumentNullException("providerFactory");

            Providers = providerFactory;
        }
    }
    public interface IProviderFactoryBase
    {
    }

}
