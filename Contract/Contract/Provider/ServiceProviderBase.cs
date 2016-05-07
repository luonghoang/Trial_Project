using SoftwareIsHardwork.ServiceModelClient.RemotingImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Provider
{
    public abstract class ServiceProviderBase<TService, TFactory> : ProviderBase<TService, TFactory>
        where TService : class
        where TFactory : IProviderFactoryBase
    {
        private string EndpointConfigurationName { get; set; }
        private TService ServiceOverride { get; set; }
        protected RealProxyServiceClientFactory ProxyFactory { get; private set; }

        public ServiceProviderBase(TFactory providerFactory, string endpointConfigurationName)
            : base(providerFactory)
        {
            ProxyFactory = new RealProxyServiceClientFactory();
            EndpointConfigurationName = endpointConfigurationName;
        }

        public ServiceProviderBase(TFactory providerFactory, TService serviceOverride)
            : this(providerFactory, "")
        {
            ServiceOverride = serviceOverride;
        }

        public ServiceProviderBase(TFactory providerFactory)
            : this(providerFactory, "")
        {
        }

        protected override TService CreateInstance()
        {
            return CreateInstance(null);
        }

        protected TService CreateInstance(string endpoint)
        {
            if (String.IsNullOrWhiteSpace(endpoint))
            {
                endpoint = EndpointConfigurationName;
            }

            if (ServiceOverride != null)
            {
                return ServiceOverride;
            }

            TService instance = null;
            try
            {
                instance = ProxyFactory.CreateInstance<TService>(endpoint);
            }
            catch (Exception e)
            {
                throw;
            }
            if (instance == null)
            {
                string error = String.Format(
                    "Failed to create instance of type {0} with endpoint {1}.",
                    typeof(TService),
                    endpoint
                    );
                throw new Exception(error);
            }
            return instance;
        }

        protected TResponse CallService<TResponse>(Func<TResponse> method)
            where TResponse : class, IResponse
        {
            try
            {
                var result = method();
                var serviceName = typeof(TService).Name;
                if (result != null && result.Status != null && result.Status.IsSuccessful)
                {
                   //log
                }
                else
                {
                    string errorDetail;
                    if (result == null)
                    {
                        errorDetail = "Result is null";
                    }
                    else if (result.Status == null)
                    {
                        errorDetail = "Status is null";
                    }
                    else if (String.IsNullOrWhiteSpace(result.Status.ErrorMessage))
                    {
                        errorDetail = "ErrorMessage is null";
                    }
                    else
                    {
                        errorDetail = result.Status.ErrorMessage;
                    }
                   
                }
                return result;
            }
            catch (FaultException fault)
            {
                HandleFault(fault);
            }
            catch (CommunicationException communication)
            {
                Monitor(communication.ToString());
            }
            catch (TimeoutException timeout)
            {
                Monitor(timeout.ToString());
            }
            return null;
        }

        protected async Task<TResponse> CallServiceAsync<TResponse>(Func<TResponse> method)
            where TResponse : class, IResponse
        {
            var task = new Task<TResponse>(() => CallService(method));
            return await task;
        }

        protected async Task<TResponse> CallServiceAsync<TResponse>(Func<Task<TResponse>> methodTask)
            where TResponse : class, IResponse
        {
            try
            {
                var result = await methodTask();
                var serviceName = typeof(TService).Name;
                if (result != null && result.Status != null && result.Status.IsSuccessful)
                {
                    //log
                }
                else
                {
                    string errorDetail;
                    if (result == null)
                    {
                        errorDetail = "Result is null";
                    }
                    else if (result.Status == null)
                    {
                        errorDetail = "Status is null";
                    }
                    else if (String.IsNullOrWhiteSpace(result.Status.ErrorMessage))
                    {
                        errorDetail = "ErrorMessage is null";
                    }
                    else
                    {
                        errorDetail = result.Status.ErrorMessage;
                    }
                }
                return result;
            }
            catch (FaultException fault)
            {
                HandleFault(fault);
            }
            catch (CommunicationException communication)
            {
                Monitor(communication.ToString());
            }
            catch (TimeoutException timeout)
            {
                Monitor(timeout.ToString());
            }
            return null;
        }

        protected virtual void HandleFault(FaultException exception)
        {
            Monitor(exception.ToString());
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                if (ProxyFactory != null)
                {
                    ProxyFactory.Dispose();
                    ProxyFactory = null;
                }
            }

            base.Dispose(disposing);
        }
    }
}
