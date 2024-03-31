using GerenciamentoImobiliario.Data.Infra.DataContext;
using GerenciamentoImobiliario.Data.Infra.Interfaces;
using GerenciamentoImobiliario.Domain.Entities;

namespace GerenciamentoImobiliario.Data.Infra.Repositories {
    public class LocacaoRepository: Repository<Locacao>, ILocacaoRepository 
    {
        public LocacaoRepository(GerenciamentoImobiliarioDataContext context) : base(context)
        {
        }
    }
}
