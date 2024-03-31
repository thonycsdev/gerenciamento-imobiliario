using GerenciamentoImobiliario.Domain.Entities;

namespace GerenciamentoImobiliario.Application.DTOs.Response
{
    public class ProprietarioResponse
    {
        public Guid Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public List<Imovel> Imoveis { get; set; } = new List<Imovel>();
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }

        public static ProprietarioResponse ToProprietarioResponse(Proprietario proprietario)
        {
            var response = new ProprietarioResponse();
            response.CPF = proprietario.CPF;
            response.Nome = proprietario.Nome;
            response.Id = proprietario.Id;
            response.CriadoEm = proprietario.CriadoEm;
            response.AtualizadoEm = proprietario.AtualizadoEm;
            response.Imoveis = proprietario.Imoveis;

            return response;
        }
    }


}
