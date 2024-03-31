using GerenciamentoImobiliario.Application.DTOs.Request;
using GerenciamentoImobiliario.Application.DTOs.Response;

namespace GerenciamentoImobiliario.Application.ServicesInterfaces
{
    public interface ICorretorService 
    {
        Task Create(CorretorRequest request);
        Task<CorretorResponse> GetById(Guid id);
        Task<IEnumerable<CorretorResponse>> GellAll();
        Task Delete(Guid id);
        Task<CorretorResponse> Update(CorretorRequest request, Guid id);
    }
}
