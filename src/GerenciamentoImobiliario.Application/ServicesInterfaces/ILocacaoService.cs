using GerenciamentoImobiliario.Application.DTOs.Request;
using GerenciamentoImobiliario.Application.DTOs.Response;

namespace GerenciamentoImobiliario.Application.ServicesInterfaces
{
    public interface ILocacaoService 
    {
        Task Create(LocacaoRequest request);
        Task<LocacaoResponse> GetById(Guid id);
        Task<IEnumerable<LocacaoResponse>> GellAll();
        Task Delete(Guid id);
        Task<LocacaoResponse> Update(LocacaoRequest request, Guid id);
    }
}
