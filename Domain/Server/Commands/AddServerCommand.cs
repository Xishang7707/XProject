using Core.Commands.Models;
using Domain.Server.Models.AddServer;

namespace Domain.Server.Commands
{
    public class AddServerCommand : Command<CommandResult>
    {
        public AddServerInfo AddServerInfo { get; }
        public AddServerCommand(string commandId, AddServerInfo addServerInfo) : base(commandId)
        {
            AddServerInfo = addServerInfo;
        }
    }
}
