using System;
using Bogus;
using FluentAssertions;
using GerenciamentoImobiliario.Domain.Entities;
using GerenciamentoImobiliario.Tests.Common;
using Xunit;

namespace GerenciamentoImobiliario.Tests.Domain.Entities
{
    [Collection(nameof(BaseFixtureCollection))]
    public class InquilinoTests
    {
        private readonly TestUtils _utils;
        public InquilinoTests(TestUtils utils)
        {
            _utils = utils;
        }

        [Fact]
        public void ShouldReturnAValidInquilinoObject()
        {
            var name = "Anthony";
            var cpf = "000.000.000-00";
            var inquilino = new Inquilino(name, cpf);
            inquilino.Nome.Should().Be(name);
            inquilino.CPF.Should().Be(cpf);
            inquilino.CriadoEm.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMinutes(1));
            inquilino.AtualizadoEm.Should().BeCloseTo(DateTime.MinValue, TimeSpan.FromMinutes(1));
        }


        [Fact]
        public void ShouldReturnAUpdatedVersionOsInquilino()
        {
            var inquilinoUpdated = _utils.CreateValidInquilino();
            var inquilino = _utils.CreateValidInquilino();

            inquilino.Update(inquilinoUpdated);
            inquilino.ImovelAlugado = inquilinoUpdated.ImovelAlugado;
            inquilino.Nome = inquilinoUpdated.Nome;
            inquilino.CPF = inquilinoUpdated.CPF;
            inquilino.AtualizadoEm.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMinutes(1));
            

        }
    }
}
