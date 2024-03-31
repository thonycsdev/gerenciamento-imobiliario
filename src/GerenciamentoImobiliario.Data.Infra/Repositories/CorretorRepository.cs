using GerenciamentoImobiliario.Data.Infra.DataContext;
using GerenciamentoImobiliario.Data.Infra.Interfaces;
using GerenciamentoImobiliario.Domain.Entities;

namespace GerenciamentoImobiliario.Data.Infra.Repositories {
    public class CorretorRepository: Repository<Corretor>, ICorretorRepository 
    {
        public CorretorRepository(GerenciamentoImobiliarioDataContext context) : base(context)
        {
        }
    }
}
