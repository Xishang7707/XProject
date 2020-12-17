using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Server.Models.DeleteServer
{
    public class DeleteServerInfo
    {
        public string Id { get; }

        public DeleteServerInfo(string id)
        {
            Id = id;
        }
    }
}
