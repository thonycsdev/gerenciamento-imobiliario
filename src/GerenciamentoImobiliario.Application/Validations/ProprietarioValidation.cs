using GerenciamentoImobiliario.Application.DTOs.Request;
using GerenciamentoImobiliario.Exception;

namespace GerenciamentoImobiliario.Application.Services.Validations
{
    public static class ProprietarioRequestValidation 
    {
        public static void Validate(this ProprietarioRequest r)
        {
            if (r.CPF == string.Empty || r.CPF == null)
            {
                throw new EntityException("CPF invalido");
            }
            r.ValidadeBase();

        }

    }
}
