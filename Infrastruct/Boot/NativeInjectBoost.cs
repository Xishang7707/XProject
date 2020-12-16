using Core.Commands;
using Infrastruct.Commands;
using Infrastruct.Configs;
using Infrastruct.DB;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruct.Boot
{
    public sealed class NativeInjectBoost
    {
        public static void Register(IServiceCollection services, params Type[] types)
        {
            RegisterConfig(services, types);
        }

        private static void RegisterConfig(IServiceCollection services, params Type[] types)
        {
            services.AddMediatR(types);
            services.AddScoped<ICommandBus, CommandBus>();
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CommandBehavor<,>));
            services.AddSingleton<DBConfig>();
            services.AddScoped<ExcDBContext>();
        }
    }
}
