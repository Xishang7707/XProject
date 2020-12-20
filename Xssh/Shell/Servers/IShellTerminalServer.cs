using Core.Servers;
using Domain.Shell.Models.OpenShell;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xssh.Shell.Servers
{
    public interface IShellTerminalServer : IServer
    {
        string OpenShell(PasswordOpenShell info);
        bool AddHub(string token);
        void RemoveHub(string token);
        void Send(string token, string str);
    }
}
