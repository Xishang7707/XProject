using Core.Repositorys;
using Domain.Models;
using Infrastruct.DB;
using Infrastruct.Repositorys;
using System.Threading.Tasks;

namespace Domain.Repositorys.Implements
{
    public class ProjectRepository : Repository<ExcDBContext>, IProjectRepository
    {
        public ProjectRepository(ExcDBContext context) : base(context) { }

        public Task<int> AddProjectAsync(SV_Project model)
        {
            string sql = @"insert into sv_project(id, projectname, addtime)
                            values(@id, @projectname, @addtime);";
            return Context.ExecuteAsync(sql, model);
        }

        public Task<bool> IsExistByProjectName(string projectName)
        {
            string sql = @"select count(1)>0 from sv_project where projectname=@projectName";
            return Context.QueryAsync<bool>(sql, new { projectName = projectName });
        }
    }
}
