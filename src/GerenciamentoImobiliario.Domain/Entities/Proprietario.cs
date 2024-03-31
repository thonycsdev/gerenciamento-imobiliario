
namespace GerenciamentoImobiliario.Domain.Entities
{
    public class Proprietario : BaseEntity
    {
        public List<Imovel> Imoveis { get; set; } = new List<Imovel>();
        public string CPF { get; set; } = string.Empty;
    }
}
