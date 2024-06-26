using GerenciamentoImobiliario.Application.DTOs.Request;
using GerenciamentoImobiliario.Application.DTOs.Response;
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
            var updateData = InquilinoRequest.ToDomainEntity(request);
            var entity = await _repository.GetById(id);
            entity.Nome = updateData.Nome;
            entity.ImovelAlugado = updateData.ImovelAlugado;
            entity.CriadoEm = updateData.CriadoEm;
            entity.CPF = updateData.CPF;
            entity.AtualizadoEm = DateTime.Now;
            await _repository.Update(entity);
            return InquilinoResponse.ToInquilinoResponse(entity);
        }
    }
}
