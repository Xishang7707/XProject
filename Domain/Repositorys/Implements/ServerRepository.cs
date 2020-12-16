using Domain.Models;
using Infrastruct.DB;
using Infrastruct.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositorys.Implements
{
    public class ServerRepository : Repository<ExcDBContext>, IServerRepository
    {
        public ServerRepository(ExcDBContext context) : base(context)
        {
        }

        public Task<int> AddServer(SV_Server model)
        {
            string sql = @"INSERT INTO sv_server(id, name, host, port, user, password, privatekey, logintype) 
                            VALUES (@id, @name, @host, @port, @user, @password, @privatekey, @logintype);";
            return Context.ExecuteAsync(sql, model);
        }

        public Task<SV_Server> Get(string id)
        {
            string sql = @"select * from sv_server where id=@id";
            return Context.QueryAsync<SV_Server>(sql, new { id });
        }

        public async Task<bool> IsExistServerName(string serverName)
        {
            string sql = @"select count(1) from sv_server where name=@serverName";
            return await Context.QueryAsync<int>(sql, new { serverName }) > 0;
        }
    }
}
