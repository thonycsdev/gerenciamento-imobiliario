using GerenciamentoImobiliario.Application.DTOs.Request;
using GerenciamentoImobiliario.Application.DTOs.Response;
using GerenciamentoImobiliario.Application.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoImobiliario.API.Controllers.inquilino
{
    [ApiController]
    [Route("[controller]")]
    public class CorretorController : ControllerBase
    {
        private readonly ICorretorService _service;
        public CorretorController(ICorretorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<CorretorResponse>> GetAllCorretorsAsync(){
            var r = await _service.GellAll();
            return r;
        }
        [HttpGet("{id}")]
        public async Task<CorretorResponse> GetById(Guid id){
            var r = await _service.GetById(id);
            return r;
        }
        [HttpPost]
        public async Task<int> Create(CorretorRequest request){
            await _service.Create(request);
            return StatusCodes.Status200OK; 
        }
        [HttpPut("{id}")]
        public async Task<CorretorResponse> GetAllCorretorsAsync(CorretorRequest request, Guid id){
            var r = await _service.Update(request, id);
            return r;
        }
        [HttpDelete("{id}")]
        public async Task<int> GetAllCorretorsAsync(Guid id){
            await _service.Delete(id);
            return StatusCodes.Status200OK;
        }
    }
}
