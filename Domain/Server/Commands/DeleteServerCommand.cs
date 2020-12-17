using Core.Commands.Models;
using Domain.Server.Models.DeleteServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Server.Commands
{
    public class DeleteServerCommand : Command<CommandResult>
    {
        public DeleteServerInfo Model { get; }

        public DeleteServerCommand(string commandId, DeleteServerInfo model) : base(commandId)
        {
            Model = model;
        }
    }
}
