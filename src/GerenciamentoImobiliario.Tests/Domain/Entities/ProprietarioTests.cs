using System;
using FluentAssertions;
using GerenciamentoImobiliario.Domain.Entities;
using GerenciamentoImobiliario.Tests.Common;
using Xunit;

namespace GerenciamentoImobiliario.Tests.Domain.Entities
{
    [Collection(nameof(BaseFixtureCollection))]
    public class ProprietarioTests
    {
        private readonly TestUtils _utils;
        public ProprietarioTests(TestUtils utils)
        {
            _utils = utils;
        }
        [Fact]
        public void ShouldReturnProprietarioObjectWithCorrectInformation()
        {
            var name = _utils._faker.Person.FullName;
            var cpf = _utils._faker.Hacker.Verb();
            var entity = new Proprietario(name, cpf);

            entity.Should().NotBeNull();
            entity.CPF.Should().Be(cpf);
            entity.Imoveis.Should().BeEmpty();
            entity.CriadoEm.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(1));
        }
        [Fact]
        public void ShouldUpdateProprietarioWithTheNewInformation()
        {

            var entity = _utils.CreateValidProprietario();
            var updatedEntity = _utils.CreateValidProprietario();

            entity.Update(updatedEntity);
            entity.Should().NotBeNull();
            entity.Nome.Should().Be(updatedEntity.Nome);
            entity.CPF.Should().Be(updatedEntity.CPF);
            entity.Imoveis.Should().BeSameAs(updatedEntity.Imoveis);
            entity.AtualizadoEm.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(1));
        }
    }
}
