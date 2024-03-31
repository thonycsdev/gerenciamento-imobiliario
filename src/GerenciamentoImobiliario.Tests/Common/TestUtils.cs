using System;
using AutoFixture;
using AutoMapper;
using GerenciamentoImobiliario.Application.AutoMapperConfig;
using GerenciamentoImobiliario.Data.Infra.DataContext;
using GerenciamentoImobiliario.Domain.Entities;
using GerenciamentoImobiliario.Tests.Common.Fixtures;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoImobiliario.Tests.Common
{

    public class TestUtils : FixturesDomain
    {
        public TestUtils() { }
        public Corretor CreateValidCorretor()
        {
            var corretor = _fixture.Create<Corretor>();
            return corretor;
        }

        public Inquilino CreateValidInquilino()
        {
            var inquilino = _fixture.Create<Inquilino>();
            return inquilino;
        }
        public Proprietario CreateValidProprietario()
        {
            var prop = _fixture.Create<Proprietario>();
            return prop;
        }
        public Imovel CreateValidImovel()
        {
            var imo = _fixture.Create<Imovel>();
            return imo;
        }

        public GerenciamentoImobiliarioDataContext CreateEFCoreInMemoryContextDatabase()
        {
            var opt = new DbContextOptionsBuilder<GerenciamentoImobiliarioDataContext>()
                .UseInMemoryDatabase(databaseName: DateTime.Now.Ticks.ToString()).Options;
            var context = new GerenciamentoImobiliarioDataContext(opt);
            return context;
        }
        public IMapper CreateMockMapper()
        {
            var mapper = new MapperConfiguration(config =>
                config.AddProfile(typeof(AutoMapperConfiguration))
            ).CreateMapper();
            return mapper;
        }

        public Locacao CreateValidLocacao()
        {
            var locacao = new Locacao(){
                Imovel = CreateValidImovel(),
                Corretor = CreateValidCorretor(),
                Inquilino = CreateValidInquilino(),
                AlugadoAte = DateTime.Now + TimeSpan.FromDays(5),
                StatusLocacao = Enums.StatusLocacao.EmAndamento,
            };
            return locacao;
        }
    }


}
