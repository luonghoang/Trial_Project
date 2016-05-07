using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial.Provider
{
    public interface IProviderFactory : IProviderFactoryBase
    {
        IUserProvider User { get; }
    }
}
