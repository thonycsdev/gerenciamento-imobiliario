
namespace GerenciamentoImobiliario.Domain.Entities
{
    public class Proprietario : BaseEntity
    {
        public List<Imovel> Imoveis { get; set; } 
        public string CPF { get; set; } = string.Empty;
        public Proprietario(string nome) : base(nome)
        {
        }

    }
}
