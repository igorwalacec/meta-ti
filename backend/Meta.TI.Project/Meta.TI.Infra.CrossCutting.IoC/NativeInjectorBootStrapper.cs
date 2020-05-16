using Meta.TI.Infra.Data.Context;
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
            //Infra - Data
            services.AddDbContext <MetaTiContext>();
        }
    }
}
