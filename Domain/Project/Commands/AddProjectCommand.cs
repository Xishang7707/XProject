using Core.Commands.Models;

namespace Domain.Project.Commands
{
    public class AddProjectCommand : Command<CommandResult>
    {
        public string ProjectName { get; }
        public AddProjectCommand(string commandId, string projectName) : base(commandId)
        {
            ProjectName = projectName;
        }
    }
}
