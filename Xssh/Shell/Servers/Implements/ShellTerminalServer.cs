using Core.Servers;
using Domain.Shell.Models.OpenShell;
using Microsoft.AspNetCore.SignalR;
using Renci.SshNet;
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
            info.InitShellStream(ShellStream_DataReceived);
            return true;
        }

        public void RemoveHub(string token)
        {
            TerminalCollection.TryRemove(token, out var info);
            info?.ShellStream?.Close();
            info?.Client.Disconnect();
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

        public void Send(string token, string str)
        {
            if (!TerminalCollection.ContainsKey(token)) return;

            ShellInfo info = TerminalCollection[token];
            info.ShellStream.WriteLine(str);
        }

        private void ShellStream_DataReceived(object sender, Renci.SshNet.Common.ShellDataEventArgs e)
        {
            ShellInfo info = TerminalCollection.Values.FirstOrDefault(f => f.ShellStream != null && f.ShellStream.Equals(sender));
            if (TerminalCollection.Values.Any(a => a == null || a.ShellStream == null))
            {
                var list = TerminalCollection.Values.Where(a => a == null || a.ShellStream == null).ToList();
                foreach (var item in list)
                {
                    TerminalCollection.TryRemove(item.Id, out _);
                }
            }
            if (info == null)
            {
                (sender as ShellStream).Close();
                return;
            }
            HubContext.Clients.User(info.Id).SendAsync("terminalstream", Encoding.Default.GetString(e.Data));
        }
    }
}
