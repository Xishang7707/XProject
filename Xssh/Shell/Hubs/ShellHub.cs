using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Xssh.Shell.Servers;
using Xssh.Shell.Servers.Implements;

namespace Xssh.Shell.Hubs
{
    public class ShellHub : Hub
    {
        private IShellTerminalServer ShellTerminalServer { get; }
        public ShellHub(IShellTerminalServer shellTerminalServer) => ShellTerminalServer = shellTerminalServer;
        public override Task OnConnectedAsync()
        {
            ShellTerminalServer.AddHub(this.GetToken());
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            ShellTerminalServer.RemoveHub(this.GetToken());
            return base.OnDisconnectedAsync(exception);
        }
    }
}
