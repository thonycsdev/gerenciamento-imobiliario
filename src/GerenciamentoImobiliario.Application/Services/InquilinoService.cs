using GerenciamentoImobiliario.Application.DTOs.Request;
using GerenciamentoImobiliario.Application.DTOs.Response;
using GerenciamentoImobiliario.Application.ServicesInterfaces;
using GerenciamentoImobiliario.Data.Infra.Interfaces;
using GerenciamentoImobiliario.Domain.Entities;
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
            var entity = InquilinoRequest.ToDomainEntity(request);
            await _repository.Create(entity);
        }

        public async Task Delete(Guid id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<InquilinoResponse>> GellAll()
        {
            var result = await _repository.GellAll();
            return result.Select(x => InquilinoResponse.ToInquilinoResponse(x));
        }

        public async Task<InquilinoResponse> GetById(Guid id)
        {
            var result = await _repository.GetById(id);
            return InquilinoResponse.ToInquilinoResponse(result);
        }

        public async Task<InquilinoResponse> Update(InquilinoRequest request, Guid id)
        {
            var updateData = new Inquilino(request.Nome, request.CPF);
            var entity = await _repository.GetById(id);
            entity.Update(updateData);
            return InquilinoResponse.ToInquilinoResponse(entity);
        }
    }
}
