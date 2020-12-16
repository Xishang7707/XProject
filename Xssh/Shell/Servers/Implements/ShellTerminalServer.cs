using Core.Servers;
using Domain.Shell.Models.OpenShell;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xssh.Shell.Hubs;
using Xssh.Shell.Servers.Models;

namespace Xssh.Shell.Servers.Implements
{
    public class ShellTerminalServer : IShellTerminalServer
    {
        private ConcurrentDictionary<string, ShellInfo> TerminalCollection { get; } = new ConcurrentDictionary<string, ShellInfo>();
        private IHubContext<ShellHub> HubContext { get; }
        public ShellTerminalServer(IHubContext<ShellHub> hubContext) => HubContext = hubContext;

        public bool AddHub(string token)
        {
            if (!TerminalCollection.ContainsKey(token)) return false;

            var info = TerminalCollection[token];
            info.Client.Connect();
            info.InitShellStream();
            return true;
        }

        public void RemoveHub(string token)
        {
            TerminalCollection.TryRemove(token, out var info);
            info.ShellStream.Close();
            info.Client.Disconnect();
        }

        public string OpenShell(PasswordOpenShell info)
        {
            string id;
            do
            {
                id = Guid.NewGuid().ToString("N");
            } while (TerminalCollection.ContainsKey(id));

            var shellInfo = new ShellInfo(id, info.Host, info.Port, info.User, info.Password);
            TerminalCollection.TryAdd(shellInfo.Id, shellInfo);
            return id;
        }

        private void ShellStream_DataReceived(object sender, Renci.SshNet.Common.ShellDataEventArgs e)
        {
            ShellInfo info = TerminalCollection.Values.First(f => f.ShellStream.Equals(sender));
            HubContext.Clients.User(info.Id).SendAsync("terminalstream", Encoding.Default.GetString(e.Data));
        }
    }
}
