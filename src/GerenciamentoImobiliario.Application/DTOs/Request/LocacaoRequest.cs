using GerenciamentoImobiliario.Application.Services.Validations;
using GerenciamentoImobiliario.Domain.Entities;

namespace GerenciamentoImobiliario.Application.DTOs.Request
{
    public class LocacaoRequest 
    {
        public Guid ImovelId { get; set; }
        public Guid InquilinoId { get; set; }
        public Guid CorretorId { get; set; }
        public DateTime AlugadoAte { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }

        public static Locacao ToDomainEntity(LocacaoRequest r)
        {
            r.Validate();
            return new Locacao
            {
                ImovelId = r.ImovelId,
                InquilinoId = r.InquilinoId,
                CorretorId = r.CorretorId,
                AlugadoAte = r.AlugadoAte,
            };
        }

    }


}
