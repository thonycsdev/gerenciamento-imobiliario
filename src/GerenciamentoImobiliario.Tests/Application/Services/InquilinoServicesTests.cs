using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using GerenciamentoImobiliario.Application.DTOs.Request;
using GerenciamentoImobiliario.Application.Services;
using GerenciamentoImobiliario.Data.Infra.Interfaces;
using GerenciamentoImobiliario.Domain.Entities;
using GerenciamentoImobiliario.Tests.Common;
using Moq;
using Xunit;

namespace GerenciamentoImobiliario.Tests.Application.Services
{
    [Collection(nameof(BaseFixtureCollection))]
    public class InquilinoServiceTests
    {
        private readonly TestUtils _utils;
        private readonly Mock<IInquilinoRepository> _repository;
        public InquilinoServiceTests(TestUtils utils)
        {
            _utils = utils;
            _repository = new Mock<IInquilinoRepository>();
        }
        [Fact]
        public async Task ShouldAdd1ToTheResultAfterInsertANewInquilinoAsync()
        {
            var list = new List<Inquilino>();
            _repository.Setup(x => x.Create(It.IsAny<Inquilino>())).Callback<Inquilino>(x => list.Add(x));
            var service = new InquilinoService(_repository.Object);
            var entity = _utils.CreateValidInquilino();
            var input = new InquilinoRequest(entity.Nome, entity.CPF);


            await service.Create(input);

            list.Count.Should().Be(1);
        }
    }
}
