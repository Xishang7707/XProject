using Core.Commands.Models;
using Core.Validator;
using Domain.Repositorys;
using Domain.Repositorys.Implements;
using Domain.Server.Commands;
using Domain.Server.Handlers;
using Domain.Server.Validator;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Server.Boot
{
    public sealed class NativeInjectBoost
    {
        public static void Register(IServiceCollection services)
        {
            RegisterHandler(services);
            RegisterValidator(services);
            RegisterRepository(services);
        }

        //private static void RegisterConfig(IServiceCollection services)
        //{

        //}

        private static void RegisterHandler(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AddServerCommand, CommandResult>, ServerHandler>();
            services.AddScoped<IRequestHandler<ConnectServerCommand, CommandDataResult<string>>, ServerHandler>();
        }

        private static void RegisterValidator(IServiceCollection services)
        {
            services.AddScoped<ICommandValidator<AddServerCommand, CommandResult>, AddServerValidation>();
            services.AddScoped<ICommandValidator<ConnectServerCommand, CommandDataResult<string>>, ConnectServerValidation>();
        }

        private static void RegisterRepository(IServiceCollection services)
        {
            services.AddScoped<IServerRepository, ServerRepository>();
        }
    }
}
