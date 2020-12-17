using Core.Commands.Models;
using Domain.Server.Models.EditServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Server.Commands
{
    public class EditServerCommand : Command<CommandResult>
    {
        public EditServerInfo Model { get; }

        public EditServerCommand(string commandId, EditServerInfo model) : base(commandId)
        {
            Model = model;
        }
    }
}
