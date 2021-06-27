using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BD;
using WBL;


namespace WebApplicationCore
{
    public static class ContainerExtensions
    {

        public static IServiceCollection AddDIContainer(this IServiceCollection services)
        {
            services.AddSingleton<IDataAccess, DataAccess>();
            services.AddTransient<IDepartamentoServicio, DepartamentoServicio>();
            services.AddTransient<IPuestoServicio, PuestoServicio>();
            services.AddTransient<ITituloServicio, TituloServicio>();
            return services;
        }
    }
}
