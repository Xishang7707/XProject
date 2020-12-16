using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xssh.Shell.Hubs
{
    public static class ShellHubExtensions
    {
        public static string GetToken(this ShellHub hub)
        {
            return hub.Context.GetHttpContext().Request.Query["user_id"];
        }
    }
}
