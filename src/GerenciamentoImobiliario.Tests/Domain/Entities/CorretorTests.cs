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
    public class CorretorTests
    {
        private readonly Fixture _fixture;
        private readonly Faker _faker;
        private readonly TestUtils _utils;
        public CorretorTests(TestUtils utils)
        {
            _faker = new Faker();
            _utils = utils;
            _fixture = new Fixture();
        }

        [Fact]
        public void ShouldReturnAValidCorretorEntity()
        {
            var nome = _faker.Person.FullName;
            var entity = new Corretor(nome);
            entity.Should().NotBeNull();
            entity.Nome.Should().Be(nome);
            entity.CriadoEm.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMinutes(1));
            entity.AtualizadoEm.Should().BeCloseTo(DateTime.MinValue, TimeSpan.FromMinutes(1));

        }

        [Fact]
        public void ShouldUpdateTheNomeAndLocacao(){
            var entity = _utils.CreateValidCorretor();
            var updatedEntity = _utils.CreateValidCorretor();
            entity.Update(updatedEntity);
            entity.Nome.Should().Be(updatedEntity.Nome);
            entity.Locacoes.Should().BeSameAs(updatedEntity.Locacoes);
            entity.AtualizadoEm.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMinutes(1));
        }
    }
}
