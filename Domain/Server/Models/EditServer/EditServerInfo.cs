using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Server.Models.EditServer
{
    public class EditServerInfo : ValueObject
    {
        public string Id { get; }
        public string Name { get; }
        public string Host { get; }
        public int Port { get; }
        public string User { get; }
        public string Password { get; }
        public string PrivateKey { get; }
        public int LoginType { get; }

        public EditServerInfo(string id, string name, string host, int port, string user, string password, string privateKey, int loginType)
        {
            Id = id;
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
