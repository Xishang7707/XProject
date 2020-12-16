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
    public class ConnectServerValidation : ServerValidation<ConnectServerCommand, CommandDataResult<string>>
    {
        public override ValidationResult IsValid(ConnectServerCommand command)
        {
            ValidateId();

            return Valid(new Domain.Models.SV_Server
            {
                Id = command.ServerIdConnect.Id
            });
        }
    }
}
