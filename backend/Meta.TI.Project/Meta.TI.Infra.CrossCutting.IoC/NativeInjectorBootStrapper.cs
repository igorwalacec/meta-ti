using Meta.TI.Application.App;
using Meta.TI.Application.Interfaces;
using Meta.TI.Domain.Handlers;
using Meta.TI.Domain.Interfaces;
using Meta.TI.Infra.Data.Context;
using Meta.TI.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Meta.TI.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<IEstadoApp, EstadoApp>();
            services.AddScoped<ICidadeApp, CidadeApp>();
            services.AddScoped<IUsuarioApp, UsuarioApp>();
            services.AddScoped<ITipoSanguineoApp, TipoSanguineoApp>();
            services.AddScoped<IAptidaoApp, AptidaoApp>();
            services.AddScoped<IDoacaoApp, DoacaoApp>();

            // Commands
            services.AddTransient<UsuarioHandler>();
            services.AddTransient<DadosAptidaoHandler>();

            // Infra - Data
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ITipoSanguineoRepository, TipoSanguineoRepository>();
            services.AddScoped<IQuestoesAptidaoRepository, QuestoesAptidaoRepository>();
            services.AddScoped<IHistoricoAptidaoRepository, HistoricoAptidaoRepository>();
            services.AddScoped<IHistoricoDoacaoRepository, HistoricoDoacaoRepository>();
            services.AddScoped<IOrientacaoDoacaoRepository, OrientacaoDoacaoRepository>();
            services.AddScoped<IStatusDoacaoRepository, StatusDoacaoRepository>();
            services.AddScoped<IResultadoAptidaoRepository, ResultadoAptidaoRepository>();
            services.AddScoped<IRespostaAptidaoRepository, RespostaAptidaoRepository>();
            services.AddDbContext<MetaTiContext>();
        }
    }
}
