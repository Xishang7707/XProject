using Core.Commands.Models;
using Domain.Server.Models.ConnectServer;
using Domain.Server.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Server.Commands
{
    public class ConnectServerCommand : Command<CommandDataResult<string>>
    {
        public ServerIdConnect ServerIdConnect { get; }
        public ConnectServerCommand(string commandId, ServerIdConnect model) : base(commandId)
        {
            ServerIdConnect = model;
        }
    }
}
