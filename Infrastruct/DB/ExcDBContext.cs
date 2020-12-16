using Infrastruct.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruct.DB
{
    public class ExcDBContext : PGSqlHelper
    {
        public ExcDBContext(DBConfig config) : base(config.ConnectionString)
        {
        }
    }
}
