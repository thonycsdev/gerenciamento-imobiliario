
namespace GerenciamentoImobiliario.Domain.Entities
{
    public class Imovel : BaseEntity
    {
        public Proprietario Proprietario { get; set; }
        public Guid ProprietarioId {get;set;}
        public bool IsDisponivel { get; set; }
    }
}
