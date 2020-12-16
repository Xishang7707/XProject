using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Server.Models.Request
{
    public class AddServerRequestModel
    {
        public string Name { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string PrivateKey { get; set; }
        public int LoginType { get; set; }
    }
}
