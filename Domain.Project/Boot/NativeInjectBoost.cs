using Core.Commands.Models;
using Core.Validator;
using Domain.Project.Commands;
using Domain.Project.Handlers;
using Domain.Project.Validator;
using Domain.Repositorys;
using Domain.Repositorys.Implements;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Project.Boot
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
            services.AddScoped<IRequestHandler<AddProjectCommand, CommandResult>, ProjectHandler>();
        }

        private static void RegisterValidator(IServiceCollection services)
        {
            services.AddScoped<ICommandValidator<AddProjectCommand, CommandResult>, AddProjectCommandValidation>();
        }

        private static void RegisterRepository(IServiceCollection services)
        {
            services.AddScoped<IProjectRepository, ProjectRepository>();
        }
    }
}
