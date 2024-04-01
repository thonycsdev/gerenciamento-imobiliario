using GerenciamentoImobiliario.Application.DTOs.Response;
using GerenciamentoImobiliario.Application.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoImobiliario.API.Controllers.inquilino
{
    [ApiController]
    [Route("[controller]")]
    public class LocacaoController : ControllerBase
    {
        private readonly ILocacaoService _service;
        public LocacaoController(ILocacaoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<LocacaoResponse>> GetAllLocacaosAsync(){
            var r = await _service.GellAll();
            return r;
        }
        [HttpGet("{id}")]
        public async Task<LocacaoResponse> GetById(Guid id){
            var r = await _service.GetById(id);
            return r;
        }
    }
}


