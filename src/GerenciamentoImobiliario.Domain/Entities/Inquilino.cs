
namespace GerenciamentoImobiliario.Domain.Entities
{
    public class Inquilino : BaseEntity
    {
        public string CPF { get; set; } = string.Empty;
        public Imovel? ImovelAlugado { get; set; }
        public string Nome {get;set;}

    }
}
