using Infrastruct.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruct.Repositorys
{
    public abstract class Repository<TContext>
        where TContext : PGSqlHelper
    {
        protected TContext Context { get; }

        public Repository(TContext context) => Context = context;
    }
}
