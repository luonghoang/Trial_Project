using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialData.Data;
using TrialData.Repository;

namespace TrialData
{
    public interface IProviderFactory : IProviderFactoryBase
    {
        IRepositoryFactory Data { get; }
    }
    public interface IRepositoryFactory
    {
        UserRepository User { get; set; }
    }

    public class ProviderFactory : IProviderFactory
    {
        public IRepositoryFactory Data { get; private set; }
        public ProviderFactory()
        {
            Data = new RepositoryFactory(new TrialEntities());
        }

        public int CacheDuration
        {
            get { throw new NotImplementedException(); }
        }

        public bool ShouldCache
        {
            get { throw new NotImplementedException(); }
        }
    }

    public class RepositoryFactory : IRepositoryFactory
    {
        private TrialEntities _trialEntities;
        private UserRepository _user;
        public RepositoryFactory(TrialEntities entities)
        {
            _trialEntities = entities;
        }
        public UserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_trialEntities);
                }
                return _user;
            }
            set
            {
                this.User = value;
            }
        }

      
    }
}
