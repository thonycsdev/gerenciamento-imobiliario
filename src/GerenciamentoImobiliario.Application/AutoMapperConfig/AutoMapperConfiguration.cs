using AutoMapper;
using GerenciamentoImobiliario.Application.DTOs.Response;
using GerenciamentoImobiliario.Domain.Entities;
namespace GerenciamentoImobiliario.Application.AutoMapperConfig
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
           CreateMap<Corretor,CorretorResponse>(); 
           CreateMap<Inquilino, InquilinoResponse>();
           CreateMap<Imovel, ImovelResponse>();
           CreateMap<Proprietario, ProprietarioResponse>();
           CreateMap<Locacao, LocacaoResponse>();
        }
    }
}
