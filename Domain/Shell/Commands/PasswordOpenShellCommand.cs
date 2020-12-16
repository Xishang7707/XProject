using Core.Commands.Models;
using Domain.Shell.Models.OpenShell;

namespace Domain.Shell.Commands
{
    public class PasswordOpenShellCommand : Command<CommandDataResult<string>>
    {
        public PasswordOpenShell PasswordOpenShell { get; set; }

        public PasswordOpenShellCommand(string commandId, PasswordOpenShell passwordOpenShell) : base(commandId)
        {
            PasswordOpenShell = passwordOpenShell;
        }
    }
}
