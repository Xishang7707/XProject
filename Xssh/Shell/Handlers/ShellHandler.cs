using Core.Commands.Models;
using Domain.Models;
using Domain.Repositorys;
using Domain.Shell.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xssh.Shell.Servers;

namespace Xssh.Shell.Handlers
{
    public class ShellHandler : IRequestHandler<PasswordOpenShellCommand, CommandDataResult<string>>
    {

        public IShellTerminalServer ShellTerminalServer { get; }

        public ShellHandler(IShellTerminalServer shellTerminalServer)
        {
            ShellTerminalServer = shellTerminalServer;
        }

        public Task<CommandDataResult<string>> Handle(PasswordOpenShellCommand request, CancellationToken cancellationToken)
        {
            string token = ShellTerminalServer.OpenShell(request.PasswordOpenShell);
            if (string.IsNullOrWhiteSpace(token))
                throw new Exception("连接失败");
            return Task.FromResult(new CommandDataResult<string>(true, "连接成功", token));
        }
    }
}
