using Meta.TI.Application.Interfaces;
using Meta.TI.Application.Services;
using Meta.TI.Domain.Interfaces;
using Meta.TI.Infra.Data.Context;
using Meta.TI.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<IEstadoService, EstadoService>();
            services.AddScoped<ICidadeService, CidadeService>();


            // Infra - Data
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddDbContext <MetaTiContext>();
        }
    }
}
