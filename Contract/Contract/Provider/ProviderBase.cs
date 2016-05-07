using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Provider
{
    public abstract class ProviderBase<TContract, TFactory> : IDisposable
        where TContract : class
        where TFactory : IProviderFactoryBase
    {

        protected TFactory ProviderFactory { get; private set; }

        protected ProviderBase(TFactory providerFactory)
        {
            if (providerFactory == null) throw new ArgumentNullException("providerFactory");

            ProviderFactory = providerFactory;
        }

        protected abstract TContract CreateInstance();

        protected virtual void Monitor(string message)
        {
           
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }

        // Dispose() calls Dispose(true)
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
