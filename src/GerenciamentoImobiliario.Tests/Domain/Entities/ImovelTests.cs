using System;
using AutoFixture;
using Bogus;
using FluentAssertions;
using GerenciamentoImobiliario.Domain.Entities;
using GerenciamentoImobiliario.Tests.Common;
using Xunit;
namespace GerenciamentoImobiliario.Tests.Domain.Entities
{
    [Collection(nameof(BaseFixtureCollection))]
    public class ImovelTests
    {
        private readonly Fixture _fixture;
        private readonly Faker _faker;
        private readonly TestUtils _utils;
        public ImovelTests(TestUtils utils)
        {
            _faker = new Faker();
            _utils = utils;
            _fixture = new Fixture();
        }

        [Fact]
        public void ShouldReturnAValidImovelEntity()
        {
            var nome = _faker.Person.FullName;
            var entity = new Imovel(nome, _utils.CreateValidProprietario());
            entity.Should().NotBeNull();
            entity.Nome.Should().Be(nome);
            entity.IsDisponivel.Should().BeTrue();
            entity.CriadoEm.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMinutes(1));
            entity.AtualizadoEm.Should().BeCloseTo(DateTime.MinValue, TimeSpan.FromMinutes(1));

        }
        [Fact]
        public void ShouldUpdateTheNomeAndLocacao()
        {
            var entity = _utils.CreateValidImovel();
            var updatedEntity = _utils.CreateValidImovel();
            entity.Update(updatedEntity);
            entity.Nome.Should().Be(updatedEntity.Nome);
            entity.Proprietario.Should().BeSameAs(updatedEntity.Proprietario);
            entity.AtualizadoEm.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMinutes(1));
        }

        [Fact]
        public void ShouldUpdateIsDisponivelToTrueWhenOcuparIsCalled()
        {
            var entity = _utils.CreateValidImovel();
            entity.Ocupar();
            entity.IsDisponivel.Should().BeFalse();
        }

        [Fact]
        public void ShouldUpdateIsDisponivelToTrueWhenLiberarIsCalled()
        {
            var entity = _utils.CreateValidImovel();
            entity.Liberar();
            entity.IsDisponivel.Should().BeTrue();
        }
    }
}

