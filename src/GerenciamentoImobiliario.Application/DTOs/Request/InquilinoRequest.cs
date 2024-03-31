using GerenciamentoImobiliario.Application.Services.Validations;
using GerenciamentoImobiliario.Domain.Entities;

namespace GerenciamentoImobiliario.Application.DTOs.Request
{
    public class InquilinoRequest : BaseRequest
    {
        public string CPF { get; set; }
        public Imovel? ImovelAlugado { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }

        public static Inquilino ToDomainEntity(InquilinoRequest r)
        {
            r.Validate();
            return new Inquilino
            {
                Nome = r.Nome,
                AtualizadoEm = r.AtualizadoEm,
                CPF = r.CPF,
                CriadoEm = r.CriadoEm,
                ImovelAlugado = r.ImovelAlugado

            };
        }

    }


}
