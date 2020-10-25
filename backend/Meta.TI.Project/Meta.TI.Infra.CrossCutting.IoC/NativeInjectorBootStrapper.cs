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
            services.AddScoped<IAgendamentoApp, AgendamentoApp>();
            services.AddScoped<ICampanhaApp, CampanhaApp>();
            services.AddScoped<ICompartilhamentoWhatsappApp, CompartilhamentoWhatsappApp>();
            services.AddScoped<IEnderecoApp, EnderecoApp>();
            services.AddScoped<IEstoqueSanguineoApp, EstoqueSanguineoApp>();
            services.AddScoped<IExpedienteApp, ExpedienteApp>();
            services.AddScoped<IFeedSolicitacaoApp, FeedSolicitacaoApp>();
            services.AddScoped<IFuncionarioApp, FuncionarioApp>();
            services.AddScoped<IHemocentroApp, HemocentroApp>();
            services.AddScoped<ITelefoneApp, TelefoneApp>();
            services.AddScoped<IAptidaoApp, AptidaoApp>();
            services.AddScoped<IDoacaoApp, DoacaoApp>();
            services.AddScoped<IRecompensasApp, RecompensasApp>();

            // Commands
            services.AddTransient<AgendamentoHandler>();
            services.AddTransient<CampanhaHandler>();
            services.AddTransient<CompartilhamentoWhatsappHandler>();
            services.AddTransient<FeedSolicitacaoHandler>();
            services.AddTransient<FuncionarioHandler>();
            services.AddTransient<HemocentroHandler>();
            services.AddTransient<UsuarioHandler>();
            services.AddTransient<DadosAptidaoHandler>();
            services.AddTransient<RecompensasHandler>();

            // Infra - Data
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ITipoSanguineoRepository, TipoSanguineoRepository>();
            services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
            services.AddScoped<ICampanhaRepository, CampanhaRepository>();
            services.AddScoped<IEstoqueSanguineoRepository, EstoqueSanguineoRepository>();
            services.AddScoped<IExpedienteRepository, ExpedienteRepository>();
            services.AddScoped<IFeedSolicitacaoRepository, FeedSolicitacaoRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IHemocentroRepository, HemocentroRepository>();
            services.AddScoped<ITelefoneRepository, TelefoneRepository>();
            services.AddScoped<IQuestoesAptidaoRepository, QuestoesAptidaoRepository>();
            services.AddScoped<IHistoricoAptidaoRepository, HistoricoAptidaoRepository>();
            services.AddScoped<IHistoricoDoacaoRepository, HistoricoDoacaoRepository>();
            services.AddScoped<IOrientacaoDoacaoRepository, OrientacaoDoacaoRepository>();
            services.AddScoped<IStatusDoacaoRepository, StatusDoacaoRepository>();
            services.AddScoped<IResultadoAptidaoRepository, ResultadoAptidaoRepository>();
            services.AddScoped<IRespostaAptidaoRepository, RespostaAptidaoRepository>();
            services.AddScoped<ILevelRepository, LevelRepository>();
            services.AddScoped<IRecompensasRepository, RecompensasRepository>();
            services.AddScoped<IPatrocinadorRepository, PatrocinadorRepository>();
            services.AddDbContext<MetaTiContext>();
        }
    }
}
