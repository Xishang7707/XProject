using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Server.Models.ConnectServer
{
    public class ServerIdConnect
    {
        public string Id { get; }

        public ServerIdConnect(string id)
        {
            Id = id;
        }
    }
}
