using GerenciamentoImobiliario.Application.Services.Validations;
using GerenciamentoImobiliario.Domain.Entities;
using GerenciamentoImobiliario.Exception;

namespace GerenciamentoImobiliario.Application.DTOs.Request
{
    public class CorretorRequest : BaseRequest
    {
        public string Nome { get; set; }

        public static Corretor ToDomainEntity(CorretorRequest r)
        {
            if (r.Nome == string.Empty || r.Nome == null)
            {
                throw new EntityException("Nome do inquilino nao permitido");
            }
            return new Corretor()
            {
                Nome = r.Nome
            };
        }
    }
}
