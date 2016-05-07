using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Contract;
using Contract.Provider;

namespace Trial.Provider
{
    public abstract class ProviderBase<TService> : ServiceProviderBase<TService, IProviderFactory>
     where TService : class
    {
        public ProviderBase(IProviderFactory factory, string endpoint) : base(factory, endpoint) { }
        public ProviderBase(IProviderFactory factory) : base(factory) { }
        public ProviderBase(IProviderFactory factory, TService serviceOverride) : base(factory, serviceOverride) { }
    }
}