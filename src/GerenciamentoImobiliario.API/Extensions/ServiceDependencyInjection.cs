using GerenciamentoImobiliario.Application.Services;
using GerenciamentoImobiliario.Application.ServicesInterfaces;

namespace GerenciamentoImobiliario.API.Extensions
{
    public static class ServiceDependencyInjection
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IInquilinoService, InquilinoService>();
            services.AddScoped<IImovelService, ImovelService>();
            services.AddScoped<IProprietarioService, ProprietarioService>();
            services.AddScoped<ICorretorService, CorretorService>();
            services.AddScoped<ILocacaoService, LocacaoService>();
        }
    }
}
