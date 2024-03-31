using GerenciamentoImobiliario.Application.DTOs.Request;
using GerenciamentoImobiliario.Application.DTOs.Response;

namespace GerenciamentoImobiliario.Application.ServicesInterfaces
{
    public interface IImovelService 
    {
        Task Create(ImovelRequest request);
        Task<ImovelResponse> GetById(Guid id);
        Task<IEnumerable<ImovelResponse>> GellAll();
        Task Delete(Guid id);
        Task<ImovelResponse> Update(ImovelRequest request, Guid id);
    }
}
