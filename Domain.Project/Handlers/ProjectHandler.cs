using Core.Commands;
using Core.Commands.Models;
using Domain.Project.Commands;
using Domain.Repositorys;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Project.Handlers
{
    public class ProjectHandler : CommandHandler,
        IRequestHandler<AddProjectCommand, CommandResult>
    {
        protected IProjectRepository ProjectRepository { get; }
        public ProjectHandler(IServiceScopeFactory serviceScopeFactory, ICommandBus commandBus, IProjectRepository projectRepository)
            : base(serviceScopeFactory, commandBus)
            => ProjectRepository = projectRepository;

        public async Task<CommandResult> Handle(AddProjectCommand request, CancellationToken cancellationToken)
        {
            bool ret;
            ret = await ProjectRepository.IsExistByProjectName(request.ProjectName);
            Assert(!ret, "已存在相同项目名称的项目");

            ret = await ProjectRepository.AddProjectAsync(new Domain.Models.SV_Project { Id = request.CommandId, ProjectName = request.ProjectName, AddTime = DateTime.Now }) > 0;
            Assert(ret, "添加失败");

            return new CommandResult(true, "添加成功");
        }
    }
}
