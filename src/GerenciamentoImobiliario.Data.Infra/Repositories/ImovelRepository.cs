using GerenciamentoImobiliario.Data.Infra.DataContext;
using GerenciamentoImobiliario.Data.Infra.Interfaces;
using GerenciamentoImobiliario.Domain.Entities;

namespace GerenciamentoImobiliario.Data.Infra.Repositories {
    public class ImovelRepository : Repository<Imovel>, IImovelRepository
    {
        public ImovelRepository(GerenciamentoImobiliarioDataContext context) : base(context)
        {
        }
    }
}
