using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Server.Models.AddServer
{
    public class AddServerInfo : ValueObject
    {
        public string Name { get; }
        public string Host { get; }
        public int Port { get; }
        public string User { get; }
        public string Password { get; }
        public string PrivateKey { get; }
        public int LoginType { get; }

        public AddServerInfo(string name, string host, int port, string user, string password, string privateKey, int loginType)
        {
            Name = name;
            Host = host;
            Port = port;
            User = user;
            Password = password;
            PrivateKey = privateKey;
            LoginType = loginType;
        }
    }
}
