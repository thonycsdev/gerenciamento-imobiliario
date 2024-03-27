
using GerenciamentoImobiliario.Enums;

namespace GerenciamentoImobiliario.Domain.Entities
{
    public class Locacao
    {

        public Guid Id { get; set; }
        public Guid ImovelId { get; set; }
        public Imovel Imovel { get; set; }
        public Guid InquilinoId { get; set; }
        public Inquilino Inquilino { get; set; }
        public Guid CorretorId { get; set; }
        public Corretor Corretor { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AlugadoAte { get; set; }
        public StatusLocacao StatusLocacao { get; set; }
    }
}
