using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class SV_Server : Entity<string>
    {
        public string Name { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string PrivateKey { get; set; }
        //连接方式(0=尝试 1=密码 2=私钥)
        public int LoginType { get; set; }
    }
}
