using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class SV_Project : Entity<string>
    {
        public string ProjectName { get; set; }
        public DateTime AddTime { get; set; }
    }
}
