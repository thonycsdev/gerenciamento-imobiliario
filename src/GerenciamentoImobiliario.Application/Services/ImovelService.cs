using GerenciamentoImobiliario.Application.DTOs.Request;
using GerenciamentoImobiliario.Application.DTOs.Response;
using GerenciamentoImobiliario.Application.ServicesInterfaces;
using GerenciamentoImobiliario.Data.Infra.Interfaces;
namespace GerenciamentoImobiliario.Application.Services
{
    public class ImovelService : IImovelService 
    {
        private readonly IImovelRepository _repository;
        public ImovelService(IImovelRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(ImovelRequest request)
        {
            var entity = ImovelRequest.ToDomainEntity(request);
            await _repository.Create(entity);
        }

        public async Task Delete(Guid id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<ImovelResponse>> GellAll()
        {
            var result = await _repository.GellAll();
            return result.Select(x => ImovelResponse.ToImovelResponse(x));
        }

        public async Task<ImovelResponse> GetById(Guid id)
        {
            var result = await _repository.GetById(id);
            return ImovelResponse.ToImovelResponse(result);
        }

        public async Task<ImovelResponse> Update(ImovelRequest request, Guid id)
        {
            var updateData = ImovelRequest.ToDomainEntity(request);
            var entity = await _repository.GetById(id);
            entity.Nome = updateData.Nome;
            entity.CriadoEm = updateData.CriadoEm;
            entity.Proprietario = updateData.Proprietario;
            entity.IsDisponivel = updateData.IsDisponivel;
            entity.AtualizadoEm = DateTime.Now;
            await _repository.Update(entity);
            return ImovelResponse.ToImovelResponse(entity);
        }
    }
}
