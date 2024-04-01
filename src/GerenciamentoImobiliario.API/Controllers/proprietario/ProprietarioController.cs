using GerenciamentoImobiliario.Application.DTOs.Request;
using GerenciamentoImobiliario.Application.DTOs.Response;
using GerenciamentoImobiliario.Application.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoImobiliario.API.Controllers.inquilino
{
    [ApiController]
    [Route("[controller]")]
    public class ProprietarioController : ControllerBase
    {
        private readonly IProprietarioService _service;
        public ProprietarioController(IProprietarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<ProprietarioResponse>> GetAllProprietariosAsync()
        {
            var r = await _service.GellAll();
            return r;
        }
        [HttpGet("{id}")]
        public async Task<ProprietarioResponse> GetById(Guid id)
        {
            var r = await _service.GetById(id);
            return r;
        }
        [HttpPost]
        public async Task<int> Create(ProprietarioRequest request)
        {
            await _service.Create(request);
            return StatusCodes.Status200OK;
        }
        [HttpPut("{id}")]
        public async Task<ProprietarioResponse> UpdateProprietario(ProprietarioRequest request, Guid id)
        {
            var r = await _service.Update(request, id);
            return r;
        }
        [HttpDelete("{id}")]
        public async Task<int> DeleteProprietario(Guid id)
        {
            await _service.Delete(id);
            return StatusCodes.Status200OK;
        }
    }
}
