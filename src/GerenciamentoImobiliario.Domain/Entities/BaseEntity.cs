namespace GerenciamentoImobiliario.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public BaseEntity(string nome)
        {
            this.Nome = nome;
        }

    }

}
