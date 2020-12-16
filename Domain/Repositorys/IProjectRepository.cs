using Core.Repositorys;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositorys
{
    public interface IProjectRepository : IRepository
    {
        Task<int> AddProjectAsync(SV_Project model);
        Task<bool> IsExistByProjectName(string projectName);
    }
}
