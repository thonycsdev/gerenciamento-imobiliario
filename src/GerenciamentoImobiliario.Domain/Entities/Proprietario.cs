
namespace GerenciamentoImobiliario.Domain.Entities
{
    public class Proprietario : BaseEntity
    {
        public List<Imovel> Imoveis { get; set; } = new List<Imovel>();
        public string CPF { get; set; } = string.Empty;
        public Proprietario(string nome, string cpf) : base(nome)
        {
            this.CPF = cpf;
            this.CriadoEm = DateTime.Now;
        }

        public void Update(Proprietario updatedEntity)
        {
            this.Nome = updatedEntity.Nome;
            this.CPF = updatedEntity.CPF;
            this.Imoveis = updatedEntity.Imoveis;
            this.AtualizadoEm = DateTime.Now;
        }
    }
}
