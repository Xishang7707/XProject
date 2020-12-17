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
    public class AddServerValidation : ServerValidation<AddServerCommand, CommandResult>
    {
        public override ValidationResult IsValid(AddServerCommand request)
        {
            ValidateName();
            ValidateHost();
            ValidatePort();
            ValidateUser();
            ValidateLoginType();
            if (request.Model.LoginType != 2)
                ValidatePassword();
            else
                ValidatePrivateKey();

            return Valid(new Domain.Models.SV_Server
            {
                Id = request.CommandId,
                Name = request.Model.Name,
                Host = request.Model.Host,
                Port = request.Model.Port,
                User = request.Model.User,
                Password = request.Model.Password,
                PrivateKey = request.Model.PrivateKey,
                LoginType = request.Model.LoginType
            });
        }
    }
}
