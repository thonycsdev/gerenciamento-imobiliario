using GerenciamentoImobiliario.Application.DTOs.Request;

namespace GerenciamentoImobiliario.Application.ServicesInterfaces
{
    public interface IInquilinoService
    {
        Task Create(InquilinoRequest request);
    }
}
