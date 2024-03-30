
using GerenciamentoImobiliario.Domain.Entities;

namespace GerenciamentoImobiliario.Application.DTOs.Response
{
    public class InquilinoResponse
    {
        public Guid Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public Imovel? ImovelAlugado { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }

        public static InquilinoResponse ToInquilinoResponse(Inquilino inquilino)
        {
            var response = new InquilinoResponse();
            response.CPF = inquilino.CPF;
            response.Nome = inquilino.Nome;
            response.ImovelAlugado = inquilino.ImovelAlugado;
            response.Id = inquilino.Id;
            response.CriadoEm = inquilino.CriadoEm;
            response.AtualizadoEm = inquilino.AtualizadoEm;

            return response;
        }
    }


}
