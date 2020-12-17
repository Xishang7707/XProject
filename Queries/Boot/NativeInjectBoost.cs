using Core.Commands;
using Infrastruct.Commands;
using Infrastruct.Configs;
using Infrastruct.DB;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Queries.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries.Boot
{
    public sealed class NativeInjectBoost
    {
        public static void Register(IServiceCollection services)
        {
            RegisterQueries(services);
        }

        private static void RegisterQueries(IServiceCollection services)
        {
            services.AddScoped<ServerQueries>();
        }
    }
}
