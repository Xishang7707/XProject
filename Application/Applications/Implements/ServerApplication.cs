using Core.Commands;
using Core.Commands.Models;
using Domain.Server.Commands;
using Domain.Server.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Applications.Implements
{
    public class ServerApplication : Core.Applications.Application, IServerApplication
    {
        public ServerApplication(ICommandBus commandBus) : base(commandBus) { }
        public Task<CommandResult> AddServer(AddServerRequestModel model)
        {
            return CommandBus.Send<AddServerCommand, CommandResult>(new AddServerCommand(
                Guid.NewGuid().ToString("N"),
                new Domain.Server.Models.AddServer.AddServerInfo(
                    model.Name,
                    model.Host,
                    model.Port,
                    model.User,
                    model.Password,
                    model.PrivateKey,
                    model.LoginType
                    )
                )
            );
        }

        public Task<CommandDataResult<string>> ConnectServer(ConnectServerRequestModel model)
        {
            return CommandBus.Send<ConnectServerCommand, CommandDataResult<string>>(new ConnectServerCommand(
                Guid.NewGuid().ToString("N"),
                new Domain.Server.Models.ConnectServer.ServerIdConnect(model.ServerId)
                ));
        }

        public Task<CommandResult> EditServer(EditServerRquestModel model)
        {
            return CommandBus.Send<EditServerCommand, CommandResult>(new EditServerCommand(
                Guid.NewGuid().ToString("N"),
                new Domain.Server.Models.EditServer.EditServerInfo(
                    model.Id,
                    model.Name,
                    model.Host,
                    model.Port,
                    model.User,
                    model.Password,
                    model.PrivateKey,
                    model.LoginType
                    )
                )
            );
        }
    }
}
