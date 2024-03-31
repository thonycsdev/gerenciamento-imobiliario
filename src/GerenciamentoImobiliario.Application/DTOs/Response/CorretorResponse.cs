using GerenciamentoImobiliario.Domain.Entities;

namespace GerenciamentoImobiliario.Application.DTOs.Response
{
    public class CorretorResponse : BaseResponse 
    {
        public string Nome { get; set; }
        public ICollection<Locacao> Locacoes { get; set; }
    }


}
