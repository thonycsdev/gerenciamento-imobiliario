using GerenciamentoImobiliario.Data.Infra.DataContext;
using GerenciamentoImobiliario.Data.Infra.Interfaces;
using GerenciamentoImobiliario.Domain.Entities;

namespace GerenciamentoImobiliario.Data.Infra.Repositories
{

    public class InquilinoRepository : Repository<Inquilino>, IInquilinoRepository
    {
        public InquilinoRepository(GerenciamentoImobiliarioDataContext context) : base(context)
        {
        }
    }
}
