using Core.Commands;
using Core.Commands.Models;
using Domain.Project.Commands;
using Domain.Project.Models.Request;
using System;
using System.Threading.Tasks;

namespace Application.Applications.Implements
{
    public class ProjectApplication : Core.Applications.Application, IProjectApplication
    {
        public ProjectApplication(ICommandBus commandBus) : base(commandBus) { }

        public Task<CommandResult> AddProject(AddProjectRequestModel model)
        {
            return CommandBus.Send<AddProjectCommand, CommandResult>(new AddProjectCommand(Guid.NewGuid().ToString("N"), model.ProjectName));
        }
    }
}
