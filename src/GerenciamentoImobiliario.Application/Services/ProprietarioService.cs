using GerenciamentoImobiliario.Application.DTOs.Request;
using GerenciamentoImobiliario.Application.DTOs.Response;
using GerenciamentoImobiliario.Application.ServicesInterfaces;
using GerenciamentoImobiliario.Data.Infra.Interfaces;
namespace GerenciamentoImobiliario.Application.Services
{
    public class ProprietarioService : IProprietarioService 
    {
        private readonly IProprietarioRepository _repository;
        public ProprietarioService(IProprietarioRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(ProprietarioRequest request)
        {
            var entity = ProprietarioRequest.ToDomainEntity(request);
            await _repository.Create(entity);
        }

        public async Task Delete(Guid id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<ProprietarioResponse>> GellAll()
        {
            var result = await _repository.GellAll();
            return result.Select(x => ProprietarioResponse.ToProprietarioResponse(x));
        }

        public async Task<ProprietarioResponse> GetById(Guid id)
        {
            var result = await _repository.GetById(id);
            return ProprietarioResponse.ToProprietarioResponse(result);
        }

        public async Task<ProprietarioResponse> Update(ProprietarioRequest request, Guid id)
        {
            var updateData = ProprietarioRequest.ToDomainEntity(request);
            var entity = await _repository.GetById(id);
            entity.Nome = updateData.Nome;
            entity.CriadoEm = updateData.CriadoEm;
            entity.Imoveis = updateData.Imoveis;
            entity.CPF = updateData.CPF;
            entity.AtualizadoEm = DateTime.Now;
            await _repository.Update(entity);
            return ProprietarioResponse.ToProprietarioResponse(entity);
        }
    }
}
