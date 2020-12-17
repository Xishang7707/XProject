using Infrastruct.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruct.DB
{
    public class QueryDBContext : PGSqlHelper
    {
        public QueryDBContext(DBConfig config) : base(config.ConnectionString)
        {
        }
    }
}
