using GerenciamentoImobiliario.Application.DTOs.Request;
using GerenciamentoImobiliario.Exception;

namespace GerenciamentoImobiliario.Application.Services.Validations
{
    public static class BaseEntityValidation
    {
        public static void ValidadeBase(this BaseRequest baseRequest)
        {
            if (baseRequest.Nome == string.Empty || baseRequest.Nome == null)
            {
                throw new EntityException("Nome do inquilino nao permitido");
            }
        }
        public static DateTime CheckCreatedAt(this BaseRequest baseRequest)
        {
            if (baseRequest.CriadoEm == DateTime.MinValue)
                baseRequest.CriadoEm = DateTime.Now;
            return baseRequest.CriadoEm;
        }
    }
}
