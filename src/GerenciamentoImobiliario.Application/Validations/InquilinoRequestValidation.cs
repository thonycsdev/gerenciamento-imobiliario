using GerenciamentoImobiliario.Application.DTOs.Request;
using GerenciamentoImobiliario.Exception;

namespace GerenciamentoImobiliario.Application.Services.Validations
{
    public static class InquilinoRequestValidation
    {
        public static void Validate(this InquilinoRequest r)
        {
            if (r.CPF == string.Empty || r.CPF == null)
            {
                throw new EntityException("CPF invalido");
            }
            r.ValidadeBase();

        }

    }
}
