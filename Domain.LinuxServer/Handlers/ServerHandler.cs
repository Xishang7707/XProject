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
        IRequestHandler<EditServerCommand, CommandResult>,
        IRequestHandler<DeleteServerCommand, CommandResult>,
        IRequestHandler<ConnectServerCommand, CommandDataResult<string>>
    {
        private IServerRepository ServerRepository { get; }
        public ServerHandler(IServiceScopeFactory serviceScopeFactory, ICommandBus commandBus, IServerRepository serverRepository) : base(serviceScopeFactory, commandBus)
        => ServerRepository = serverRepository;

        public async Task<CommandResult> Handle(AddServerCommand request, CancellationToken cancellationToken)
        {
            bool ret;
            ret = await ServerRepository.IsExistServerName(request.Model.Name);
            Assert(!ret, "已存在相同名称的服务器");

            ret = await ServerRepository.AddServer(new Domain.Models.SV_Server
            {
                Id = request.CommandId,
                Name = request.Model.Name,
                Host = request.Model.Host,
                Port = request.Model.Port,
                User = request.Model.User,
                Password = request.Model.Password,
                PrivateKey = request.Model.PrivateKey,
                LoginType = request.Model.LoginType
            }) > 0;
            Assert(ret, "添加失败");

            return new CommandResult(true, "添加成功");
        }

        public async Task<CommandDataResult<string>> Handle(ConnectServerCommand request, CancellationToken cancellationToken)
        {
            var server = await ServerRepository.Get(request.ServerIdConnect.Id);
            Assert(server is not null, "服务器不存在");

            return await CommandBus.Send<PasswordOpenShellCommand, CommandDataResult<string>>(
                new PasswordOpenShellCommand(
                    request.CommandId,
                    new PasswordOpenShell(server.Host, server.Port, server.User, server.Password)
                ));
        }

        public async Task<CommandResult> Handle(EditServerCommand request, CancellationToken cancellationToken)
        {
            var server = await ServerRepository.Get(request.Model.Id);
            Assert(server is not null, "服务器不存在");

            bool ret;
            ret = await ServerRepository.IsExistServerName(request.Model.Id, request.Model.Name);
            Assert(!ret, "已存在相同名称的服务器");

            ret = await ServerRepository.EditServer(new Domain.Models.SV_Server
            {
                Id = request.Model.Id,
                Name = request.Model.Name,
                Host = request.Model.Host,
                Port = request.Model.Port,
                User = request.Model.User,
                Password = request.Model.Password,
                PrivateKey = request.Model.PrivateKey,
                LoginType = request.Model.LoginType
            }) > 0;
            Assert(ret, "修改失败");

            return new CommandResult(true, "修改成功");
        }

        public async Task<CommandResult> Handle(DeleteServerCommand request, CancellationToken cancellationToken)
        {
            bool ret = await ServerRepository.DeleteServer(request.Model.Id) > 0;
            Assert(ret, "删除失败或数据已被删除");

            return new CommandResult(true, "修改成功");
        }
    }
}
