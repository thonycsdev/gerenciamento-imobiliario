namespace GerenciamentoImobiliario.Application.DTOs.Response
{
    public class BaseResponse 
    {
        public Guid Id { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }

    }


}
