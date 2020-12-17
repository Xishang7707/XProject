using Core.Repositorys;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositorys
{
    public interface IServerRepository : IRepository
    {
        Task<int> AddServer(SV_Server model);
        Task<int> DeleteServer(string id);
        Task<bool> IsExistServerName(string serverName);
        Task<bool> IsExistServerName(string id, string serverName);
        Task<SV_Server> Get(string id);
        Task<int> EditServer(SV_Server model);
    }
}
