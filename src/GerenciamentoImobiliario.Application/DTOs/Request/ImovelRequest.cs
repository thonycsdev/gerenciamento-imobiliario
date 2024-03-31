using GerenciamentoImobiliario.Domain.Entities;

namespace GerenciamentoImobiliario.Application.DTOs.Request
{
    public class ImovelRequest: BaseRequest
    {
        public Guid ProprietarioId { get; set; }
        public bool IsDisponivel { get; set; }

        public static Imovel ToDomainEntity(ImovelRequest r)
        {
            //r.Validate();
            return new Imovel()
            {
                Nome = r.Nome,
            };
        }

    }


}
