
namespace GerenciamentoImobiliario.Domain.Entities
{
    public class Corretor : BaseEntity
    {
        public ICollection<Locacao> Locacoes { get; set; }
    }
}
