using GerenciamentoImobiliario.Application.DTOs.Request;
using GerenciamentoImobiliario.Application.DTOs.Response;
using GerenciamentoImobiliario.Application.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoImobiliario.API.Controllers.inquilino
{
    [ApiController]
    [Route("[controller]")]
    public class ImovelController : ControllerBase
    {
        private readonly IImovelService _service;
        public ImovelController(IImovelService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<ImovelResponse>> GetAllImovelsAsync(){
            var r = await _service.GellAll();
            return r;
        }
        [HttpGet("{id}")]
        public async Task<ImovelResponse> GetById(Guid id){
            var r = await _service.GetById(id);
            return r;
        }
        [HttpPost]
        public async Task<int> Create(ImovelRequest request){
            await _service.Create(request);
            return StatusCodes.Status200OK; 
        }
        [HttpPut("{id}")]
        public async Task<ImovelResponse> GetAllImovelsAsync(ImovelRequest request, Guid id){
            var r = await _service.Update(request, id);
            return r;
        }
        [HttpDelete("{id}")]
        public async Task<int> GetAllImovelsAsync(Guid id){
            await _service.Delete(id);
            return StatusCodes.Status200OK;
        }
    }
}
