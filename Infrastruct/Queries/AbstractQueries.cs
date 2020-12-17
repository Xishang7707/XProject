using Infrastruct.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruct.Queries
{
    public abstract class AbstractQueries<TContext>
        where TContext : PGSqlHelper
    {
        protected TContext Context { get; }

        public AbstractQueries(TContext context) => Context = context;
    }
}
