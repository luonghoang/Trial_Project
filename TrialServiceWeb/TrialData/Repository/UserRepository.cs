using Contract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using TrialData.Data;

namespace TrialData.Repository
{
    public class UserRepository : Repository<TrialEntities, M_User, int>
    {
        public UserRepository(TrialEntities entities) : base(entities) { }

        protected override DbSet<M_User> DbSet
        {
            get { return Context.M_User; }
        }
    }
}
