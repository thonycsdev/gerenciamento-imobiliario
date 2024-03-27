
namespace GerenciamentoImobiliario.Domain.Entities
{
    public class Imovel : BaseEntity
    {
        public Proprietario Proprietario { get; set; }
        public bool IsDisponivel { get; set; }
        public Imovel(string nome, Proprietario proprietario) : base(nome)
        {
            Proprietario = proprietario;
            IsDisponivel = true;
            CriadoEm = DateTime.Now;

        }

        public Imovel Update(Imovel updatedEntity)
        {
            this.Proprietario = updatedEntity.Proprietario;
            this.AtualizadoEm = DateTime.Now;
            this.Nome = updatedEntity.Nome;
            this.IsDisponivel = updatedEntity.IsDisponivel;
            return this;
        }

        public void Ocupar()
        {
            this.IsDisponivel = false;
        }

        public void Liberar()
        {
            this.IsDisponivel = true;
        }
    }
}
