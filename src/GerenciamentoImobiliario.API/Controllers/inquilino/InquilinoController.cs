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
    }
}
