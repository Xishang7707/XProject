using Core.Commands;
using Core.Commands.Models;
using Domain.Repositorys;
using Domain.Server.Commands;
using Domain.Shell.Commands;
using Domain.Shell.Models.OpenShell;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Server.Handlers
{
    public class ServerHandler : CommandHandler,
        IRequestHandler<AddServerCommand, CommandResult>,
        IRequestHandler<ConnectServerCommand, CommandDataResult<string>>
    {
        private IServerRepository ServerRepository { get; }
        public ServerHandler(IServiceScopeFactory serviceScopeFactory, ICommandBus commandBus, IServerRepository serverRepository) : base(serviceScopeFactory, commandBus)
        => ServerRepository = serverRepository;

        public async Task<CommandResult> Handle(AddServerCommand request, CancellationToken cancellationToken)
        {
            bool ret;
            ret = await ServerRepository.IsExistServerName(request.AddServerInfo.Name);
            Assert(!ret, "已存在相同名称的服务器");

            ret = await ServerRepository.AddServer(new Domain.Models.SV_Server
            {
                Id = request.CommandId,
                Name = request.AddServerInfo.Name,
                Host = request.AddServerInfo.Host,
                Port = request.AddServerInfo.Port,
                User = request.AddServerInfo.User,
                Password = request.AddServerInfo.Password,
                PrivateKey = request.AddServerInfo.PrivateKey,
                LoginType = 0
            }) > 0;
            Assert(ret, "添加失败");

            return new CommandResult(true, "添加成功");
        }

        public async Task<CommandDataResult<string>> Handle(ConnectServerCommand request, CancellationToken cancellationToken)
        {
            var server = await ServerRepository.Get(request.ServerIdConnect.Id);
            if (server == null)
                throw new Exception("服务器不存在");

            return await CommandBus.Send<PasswordOpenShellCommand, CommandDataResult<string>>(
                new PasswordOpenShellCommand(
                    request.CommandId,
                    new PasswordOpenShell(server.Host, server.Port, server.User, server.Password)
                ));
        }
    }
}
