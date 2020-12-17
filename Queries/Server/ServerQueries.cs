using BootstrapBlazor.Components;
using Domain.Models;
using Domain.Server.Models.Request;
using Infrastruct.DB;
using Infrastruct.Queries;
using Queries.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Queries.Server
{
    public class ServerQueries : AbstractQueries<QueryDBContext>
    {
        public ServerQueries(QueryDBContext context) : base(context)
        {
        }

        public async Task<QueryData<ServerItem>> GetList(QueryPageOptions query)
        {
            int pass = (query.PageIndex - 1) * query.PageItems;
            string sql = $"select * from sv_server limit @PageItems offset @pass";
            string sqlcount = "select count(1) from sv_server";

            return new QueryData<ServerItem>
            {
                Items = await Context.QueryListAsync<ServerItem>(sql, new { query.PageItems, pass }),
                TotalCount = await Context.QueryAsync<int>(sqlcount)
            };
        }

        public Task<EditServerRequestModel> Get(string id)
        {
            string sql = "select * from sv_server where id=@id";
            return Context.QueryAsync<EditServerRequestModel>(sql, new { id });
        }
    }
}
