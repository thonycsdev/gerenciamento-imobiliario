
namespace GerenciamentoImobiliario.Domain.Entities
{
    public class Inquilino : BaseEntity
    {
        public string CPF { get; set; } = string.Empty;
        public Imovel? ImovelAlugado { get; set; }
        public Inquilino(string nome, string cpf) : base(nome)
        {
            this.Nome = nome;
            this.CPF = cpf;
            this.CriadoEm = DateTime.Now;
        }


        public Inquilino Update(Inquilino inquilino){
            this.Nome = inquilino.Nome;
            this.CPF = inquilino.CPF;
            this.ImovelAlugado = inquilino.ImovelAlugado;
            this.AtualizadoEm = DateTime.Now;

            return this; 
        }

    }
}
