using Core.Commands.Models;
using Domain.Server.Models.AddServer;

namespace Domain.Server.Commands
{
    public class AddServerCommand : Command<CommandResult>
    {
        public AddServerInfo Model { get; }
        public AddServerCommand(string commandId, AddServerInfo addServerInfo) : base(commandId)
        {
            Model = addServerInfo;
        }
    }
}
