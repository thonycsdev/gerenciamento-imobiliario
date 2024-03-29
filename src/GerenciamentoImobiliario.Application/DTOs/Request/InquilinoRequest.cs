using GerenciamentoImobiliario.Domain.Entities;

namespace GerenciamentoImobiliario.Application.DTOs.Request
{
    public class InquilinoRequest
    {
        public string CPF { get; set; }
        public string Nome { get; set; }

        public InquilinoRequest(string nome, string cpf)
        {
           this.CPF = cpf;
           this.Nome = nome;
        }
        public static Inquilino ToDomainEntity(InquilinoRequest r)
        {
            var entity = new Inquilino(r.Nome, r.CPF);
            return entity;
        }
    }


}
