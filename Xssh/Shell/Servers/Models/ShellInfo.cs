using Renci.SshNet;
using Renci.SshNet.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xssh.Shell.Hubs;

namespace Xssh.Shell.Servers.Models
{
    public class ShellInfo
    {
        public string Id { get; }
        public SshClient Client { get; }
        public ShellStream ShellStream { get; protected set; }
        public ShellHub ShellHub { get; set; }

        public ShellInfo(string id, string host, int port, string user, string password)
        {
            Id = id;
            Client = new SshClient(host, port, user, password);
        }

        public void InitShellStream(EventHandler<ShellDataEventArgs> @event)
        {
            ShellStream = Client.CreateShellStream(Id, 1024, 1024, 1024, 1024, 65535);
            ShellStream.DataReceived += @event;
        }
    }
}
