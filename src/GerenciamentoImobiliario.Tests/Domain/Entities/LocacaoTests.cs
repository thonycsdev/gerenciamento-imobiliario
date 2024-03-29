using System;
using AutoFixture;
using Bogus;
using FluentAssertions;
using GerenciamentoImobiliario.Domain.Entities;
using GerenciamentoImobiliario.Exceptio;
using GerenciamentoImobiliario.Tests.Common;
using Xunit;

namespace GerenciamentoImobiliario.Tests.Domain.Entities
{
    [Collection(nameof(BaseFixtureCollection))]
    public class LocacaoTests
    {
        private readonly TestUtils _utils;
        private readonly Fixture _fixture;
        private readonly Faker _faker;


        public LocacaoTests(TestUtils utils)
        {
            _faker = new Faker();
            _utils = utils;
            _fixture = new Fixture();
        }


        [Fact]
        public void GivenValidInformationCreateANewLocacaoWithTheCorrectData()
        {
            var imovel = _utils.CreateValidImovel();
            var inquilino = _utils.CreateValidInquilino();
            var corretor = _utils.CreateValidCorretor();
            var alugadoAte = DateTime.Now + TimeSpan.FromDays(5);
            var locacao = new Locacao(imovel, inquilino, corretor, alugadoAte);

            locacao.Should().NotBeNull();
            locacao.CriadoEm.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(1));
            locacao.Inquilino.Should().BeSameAs(inquilino);
            locacao.Imovel.Should().BeSameAs(imovel);
            locacao.Corretor.Should().BeSameAs(corretor);
            locacao.AlugadoAte.Should().Be(alugadoAte);

            locacao.StatusLocacao.Should().Be(Enums.StatusLocacao.EmAndamento);
        }


        [Fact]
        public void GivenAIndisponivelImovelShouldThrowAError()
        {
            var imovel = _utils.CreateValidImovel();
            imovel.Ocupar();
            var inquilino = _utils.CreateValidInquilino();
            var corretor = _utils.CreateValidCorretor();
            var alugadoAte = DateTime.Now + TimeSpan.FromDays(5);
            Action action = () => new Locacao(imovel, inquilino, corretor, alugadoAte);

            action.Should().Throw<EntityException>().WithMessage("Imovel informado esta ocupado");

        }
        [Fact]
        public void GivenAAlugadoAteInThePassShouldThrowAnError()
        {
            var imovel = _utils.CreateValidImovel();
            var inquilino = _utils.CreateValidInquilino();
            var corretor = _utils.CreateValidCorretor();
            var alugadoAte = DateTime.Now + TimeSpan.FromDays(-5);
            Action action = () => new Locacao(imovel, inquilino, corretor, alugadoAte);

            action.Should().Throw<EntityException>().WithMessage("Data de locacao esta invalida");

        }
        [Fact]
        public void GivenAAlugadoAteIn30DaysInTheFutureShouldThrowAnError()
        {
            var imovel = _utils.CreateValidImovel();
            var inquilino = _utils.CreateValidInquilino();
            var corretor = _utils.CreateValidCorretor();
            var alugadoAte = DateTime.Now + TimeSpan.FromDays(31);
            Action action = () => new Locacao(imovel, inquilino, corretor, alugadoAte);

            action.Should().Throw<EntityException>().WithMessage("Data de locacao esta invalida");

        }
        [Fact]
        public void GiveSomeDependencyAsNullShouldThrowAnError()
        {
            
            var imovel = _utils.CreateValidImovel();
            var inquilino = _utils.CreateValidInquilino();
            Corretor? corretor = null;
            var alugadoAte = DateTime.Now; 

            Action action = () => new Locacao(imovel, inquilino, corretor, alugadoAte);

            action.Should().Throw<EntityException>().WithMessage("Valide as Informacoes das entidades fornecidas");
        }
    }
}
