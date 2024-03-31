using GerenciamentoImobiliario.Application.Services.Validations;
using GerenciamentoImobiliario.Domain.Entities;

namespace GerenciamentoImobiliario.Application.DTOs.Request
{
    public class ProprietarioRequest : BaseRequest
    {
        public List<Imovel> Imoveis { get; set; } = new List<Imovel>();
        public string CPF { get; set; } = string.Empty;

        public static Proprietario ToDomainEntity(ProprietarioRequest r)
        {
            r.Validate();
            return new Proprietario()
            {
                Nome = r.Nome,
                CPF = r.CPF,
                CriadoEm = r.CriadoEm,
                Imoveis = r.Imoveis,
                AtualizadoEm = r.AtualizadoEm
            };
        }

    }


}
