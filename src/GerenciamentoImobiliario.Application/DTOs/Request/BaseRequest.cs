namespace GerenciamentoImobiliario.Application.DTOs.Request
{
    public class BaseRequest
    {
        public string Nome { get; set; } = string.Empty;
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
    }
}
