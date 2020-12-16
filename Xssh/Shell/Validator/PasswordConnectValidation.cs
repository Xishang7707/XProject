using Core.Commands.Models;
using Domain.Shell.Commands;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xssh.Shell.Validator
{
    public class PasswordConnectValidation : ShellValidation<PasswordOpenShellCommand, CommandDataResult<string>>
    {
        public override ValidationResult IsValid(PasswordOpenShellCommand command)
        {
            return Validate(new Domain.Models.SV_Server
            {
                Host = command.PasswordOpenShell.Host,
                Port = command.PasswordOpenShell.Port,
                User = command.PasswordOpenShell.User,
                Password = command.PasswordOpenShell.Password,
            });
        }
    }
}
