using Core.Commands.Models;
using Core.Models;
using Core.Validator;
using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Project.Validator
{
    public abstract class ProjectValidation<TCommand, TResult> : CommandValidator<TCommand, TResult, SV_Project>
       where TCommand : Command<TResult>
       where TResult : CommandResult, new()
    {
        protected void ValidateProjectName()
        {
            RuleFor(r => r.ProjectName)
                .NotEmpty().WithMessage("项目名称不能为空")
                .MaximumLength(30).WithMessage("项目名称最多30个字符");
        }
    }
}
