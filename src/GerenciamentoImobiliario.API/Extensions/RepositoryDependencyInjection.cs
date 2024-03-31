using GerenciamentoImobiliario.Data.Infra.Interfaces;
using GerenciamentoImobiliario.Data.Infra.Repositories;

namespace GerenciamentoImobiliario.API.Extensions
{
    public static class RepositoryDependencyInjection
    {
        public static void ConfigureRepositories(this IServiceCollection services){
            services.AddScoped<IInquilinoRepository, InquilinoRepository>();
        }
    }
}
