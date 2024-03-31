using GerenciamentoImobiliario.Application.DTOs.Request;
using GerenciamentoImobiliario.Exception;
namespace GerenciamentoImobiliario.Application.Services.Validations
{
    public static class LocacaoRequestValidation 
    {
        public static void Validate(this LocacaoRequest r)
        {
            if (r.AlugadoAte == DateTime.MinValue){
                throw new EntityException("Data de AlugadoAte Invalida");
            }

            if(r.CorretorId == Guid.Empty || r.InquilinoId == Guid.Empty || r.ImovelId == Guid.Empty)
                throw new EntityException("Confira os IDS informados");
        }

    }
}
