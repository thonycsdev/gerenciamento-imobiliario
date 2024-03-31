using AutoMapper;
using GerenciamentoImobiliario.Application.DTOs.Request;
using GerenciamentoImobiliario.Application.DTOs.Response;
using GerenciamentoImobiliario.Application.ServicesInterfaces;
using GerenciamentoImobiliario.Data.Infra.Interfaces;
namespace GerenciamentoImobiliario.Application.Services
{
    public class CorretorService : ICorretorService 
    {
        private readonly ICorretorRepository _repository;
        private readonly IMapper _mapper;
        public CorretorService(ICorretorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Create(CorretorRequest request)
        {
            var entity = CorretorRequest.ToDomainEntity(request);
            await _repository.Create(entity);
        }

        public async Task Delete(Guid id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<CorretorResponse>> GellAll()
        {
            var result = await _repository.GellAll();
            return _mapper.Map<IEnumerable<CorretorResponse>>(result);
        }

        public async Task<CorretorResponse> GetById(Guid id)
        {
            var result = await _repository.GetById(id);
            return _mapper.Map<CorretorResponse>(result);
        }

        public async Task<CorretorResponse> Update(CorretorRequest request, Guid id)
        {
            var updateData = CorretorRequest.ToDomainEntity(request);
            var entity = await _repository.GetById(id);
            entity.Nome = updateData.Nome;
            entity.CriadoEm = updateData.CriadoEm;
            entity.Locacoes = updateData.Locacoes;
            entity.AtualizadoEm = DateTime.Now;
            await _repository.Update(entity);
            return _mapper.Map<CorretorResponse>(entity);
        }
    }
}
