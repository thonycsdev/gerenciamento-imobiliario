
namespace GerenciamentoImobiliario.Domain.Entities
{
    public class Corretor : BaseEntity
    {
        public ICollection<Locacao> Locacoes{ get; set; } = new List<Locacao>();
        public Corretor(string name) : base(name)
        {
            this.Nome = name;
            this.CriadoEm = DateTime.Now;
        }


        public Corretor Update(Corretor corretor)
        {
            this.Nome = corretor.Nome;
            this.Locacoes= corretor.Locacoes;
            this.AtualizadoEm = DateTime.Now;
            return this;
        }

    }
}
