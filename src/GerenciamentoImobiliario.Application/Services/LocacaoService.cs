using AutoMapper;
using GerenciamentoImobiliario.Application.DTOs.Request;
using GerenciamentoImobiliario.Application.DTOs.Response;
using GerenciamentoImobiliario.Application.ServicesInterfaces;
using GerenciamentoImobiliario.Data.Infra.Interfaces;
namespace GerenciamentoImobiliario.Application.Services
{
    public class LocacaoService : ILocacaoService 
    {
        private readonly ILocacaoRepository _repository;
        private readonly IMapper _mapper;
        public LocacaoService(ILocacaoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Create(LocacaoRequest request)
        {
            var entity = LocacaoRequest.ToDomainEntity(request);
            await _repository.Create(entity);
        }

        public async Task Delete(Guid id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<LocacaoResponse>> GellAll()
        {
            var result = await _repository.GellAll();
            return _mapper.Map<IEnumerable<LocacaoResponse>>(result);
        }

        public async Task<LocacaoResponse> GetById(Guid id)
        {
            var result = await _repository.GetById(id);
            return _mapper.Map<LocacaoResponse>(result);
        }

        public async Task<LocacaoResponse> Update(LocacaoRequest request, Guid id)
        {
            var updateData = LocacaoRequest.ToDomainEntity(request);
            var entity = await _repository.GetById(id);
            entity.ImovelId =  request.ImovelId;
            entity.InquilinoId = request.InquilinoId;
            entity.CorretorId = request.CorretorId;
            entity.AlugadoAte = request.AlugadoAte;
            entity.AtualizadoEm = DateTime.Now;
            await _repository.Update(entity);
            return _mapper.Map<LocacaoResponse>(entity);
        }
    }
}
