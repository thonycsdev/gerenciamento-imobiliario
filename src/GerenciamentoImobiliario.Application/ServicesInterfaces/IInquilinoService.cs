using GerenciamentoImobiliario.Application.DTOs.Request;
using GerenciamentoImobiliario.Application.DTOs.Response;

namespace GerenciamentoImobiliario.Application.ServicesInterfaces
{
    public interface IInquilinoService
    {
        Task Create(InquilinoRequest request);
        Task<InquilinoResponse> GetById(Guid id);
        Task<IEnumerable<InquilinoResponse>> GellAll();
        Task Delete(Guid id);
        Task<InquilinoResponse> Update(InquilinoRequest request, Guid id);
    }
}
