using GerenciamentoImobiliario.Application.DTOs.Request;
using GerenciamentoImobiliario.Application.DTOs.Response;

namespace GerenciamentoImobiliario.Application.ServicesInterfaces
{
    public interface IProprietarioService 
    {
        Task Create(ProprietarioRequest request);
        Task<ProprietarioResponse> GetById(Guid id);
        Task<IEnumerable<ProprietarioResponse>> GellAll();
        Task Delete(Guid id);
        Task<ProprietarioResponse> Update(ProprietarioRequest request, Guid id);
    }
}
