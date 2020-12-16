using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shell.Models.OpenShell
{
    public class PasswordOpenShell : ValueObject
    {
        public string Host { get; }
        public int Port { get; }
        public string User { get; }
        public string Password { get; }

        public PasswordOpenShell(string host, int port, string user, string password)
        {
            Host = host;
            Port = port;
            User = user;
            Password = password;
        }
    }
}
