using GerenciamentoImobiliario.Application.DTOs.Request;
using GerenciamentoImobiliario.Application.DTOs.Response;
using GerenciamentoImobiliario.Application.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoImobiliario.API.Controllers.inquilino
{
    [ApiController]
    [Route("[controller]")]
    public class InquilinoController : ControllerBase
    {
        private readonly IInquilinoService _service;
        public InquilinoController(IInquilinoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<InquilinoResponse>> GetAllInquilinosAsync(){
            var r = await _service.GellAll();
            return r;
        }
        [HttpGet("{id}")]
        public async Task<InquilinoResponse> GetById(Guid id){
            var r = await _service.GetById(id);
            return r;
        }
        [HttpPost]
        public async Task<int> Create(InquilinoRequest request){
            await _service.Create(request);
            return StatusCodes.Status200OK; 
        }
        [HttpPut("{id}")]
        public async Task<InquilinoResponse> GetAllInquilinosAsync(InquilinoRequest request, Guid id){
            var r = await _service.Update(request, id);
            return r;
        }
        [HttpDelete("{id}")]
        public async Task<int> GetAllInquilinosAsync(Guid id){
            await _service.Delete(id);
            return StatusCodes.Status200OK;
        }
    }
}
