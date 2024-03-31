using GerenciamentoImobiliario.Application.Services;
using GerenciamentoImobiliario.Application.ServicesInterfaces;

namespace GerenciamentoImobiliario.API.Extensions
{
    public static class ServiceDependencyInjection
    {
        public static void ConfigureServices(this IServiceCollection services){
            services.AddScoped<IInquilinoService, InquilinoService>();    
        }
    }
}
