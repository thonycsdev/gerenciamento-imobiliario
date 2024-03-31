using GerenciamentoImobiliario.Domain.Entities;

namespace GerenciamentoImobiliario.Application.DTOs.Response
{
    public class ImovelResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Proprietario Proprietario { get; set; }
        public bool IsDisponivel {get;set;}
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }

        public static ImovelResponse ToImovelResponse (Imovel imovel)
        {
            var response = new ImovelResponse();
            response.Nome = imovel.Nome;
            response.Proprietario = imovel.Proprietario;
            response.IsDisponivel = imovel.IsDisponivel;
            response.Id = imovel.Id;
            response.CriadoEm = imovel.CriadoEm;
            response.AtualizadoEm = imovel.AtualizadoEm;

            return response;
        }
    }


}
