using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruct.Configs
{
    public class DBConfig
    {
        public string ConnectionString { get; }
        public DBConfig(IConfiguration config)
        {
            ConnectionString = config.GetConnectionString("pg-write");
        }
    }
}
