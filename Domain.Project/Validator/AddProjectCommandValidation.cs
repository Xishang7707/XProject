using Core.Commands.Models;
using Domain.Models;
using Domain.Project.Commands;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Project.Validator
{
    public class AddProjectCommandValidation : ProjectValidation<AddProjectCommand, CommandResult>
    {
        public AddProjectCommandValidation()
        {
            ValidateProjectName();
        }

        public override ValidationResult IsValid(AddProjectCommand command)
        {
            return Valid(new SV_Project
            {
                ProjectName = command.ProjectName
            });
        }
    }
}
