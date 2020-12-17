using Core.Commands.Models;
using Domain.Server.Commands;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Server.Validator
{
    public class DeleteServerValidation : ServerValidation<DeleteServerCommand, CommandResult>
    {
        public override ValidationResult IsValid(DeleteServerCommand command)
        {
            ValidateId();

            return Valid(new Domain.Models.SV_Server
            {
                Id = command.Model.Id
            });
        }
    }
}
