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
            string sql = "INSERT INTO sv_server(id, name, host, port, \"user\", password, privatekey, logintype)" +
                           "VALUES (@id, @name, @host, @port, @user, @password, @privatekey, @logintype);";
            return Context.ExecuteAsync(sql, model);
        }

        public Task<int> EditServer(SV_Server model)
        {
            string sql = "update sv_server set name=@name, host=@host, port=@port, \"user\"=@user, password=@pssword, privatekey=@privatekey, logintype=@logintype where id=@id";
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

        public async Task<bool> IsExistServerName(string id, string serverName)
        {
            string sql = @"select count(1) from sv_server where id!=@id and name=@serverName";
            return await Context.QueryAsync<int>(sql, new { id, serverName }) > 0;
        }
    }
}
