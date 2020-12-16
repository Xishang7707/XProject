using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Project.Models.AddProject
{
    public class AddProjectInfo : ValueObject
    {
        public string ProjectName { get; }
        public DateTime AddTime { get; }

        public AddProjectInfo(string projectName)
        {
            ProjectName = projectName;
        }

        public AddProjectInfo(string projectName, DateTime addTime) : this(projectName)
        {
            AddTime = addTime;
        }
    }
}
