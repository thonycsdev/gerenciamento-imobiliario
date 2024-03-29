using GerenciamentoImobiliario.Application.DTOs.Request;
using GerenciamentoImobiliario.Application.ServicesInterfaces;
using GerenciamentoImobiliario.Data.Infra.Interfaces;
namespace GerenciamentoImobiliario.Application.Services
{
    public class InquilinoService : IInquilinoService
    {
        private readonly IInquilinoRepository _repository;
        public InquilinoService(IInquilinoRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(InquilinoRequest request)
        {
            var entity =  InquilinoRequest.ToDomainEntity(request);
            await _repository.Create(entity);
        }
    }
}
