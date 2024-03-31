using GerenciamentoImobiliario.Enums;

namespace GerenciamentoImobiliario.Application.DTOs.Response
{
    public class LocacaoResponse : BaseResponse 
    {
        public ImovelResponse Imovel { get; set; }
        public InquilinoResponse Inquilino { get; set; }
        public CorretorResponse Corretor { get; set; }
        public DateTime AlugadoAte { get; set; }
        public StatusLocacao StatusLocacao { get; set; }

    }


}
