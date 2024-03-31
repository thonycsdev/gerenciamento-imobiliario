
using GerenciamentoImobiliario.Data.Infra.DataContext;
using GerenciamentoImobiliario.Data.Infra.Interfaces;
using GerenciamentoImobiliario.Domain.Entities;

namespace GerenciamentoImobiliario.Data.Infra.Repositories {
    public class ProprietarioRepository: Repository<Proprietario>, IProprietarioRepository 
    {
        public ProprietarioRepository(GerenciamentoImobiliarioDataContext context) : base(context)
        {
        }
    }
}
