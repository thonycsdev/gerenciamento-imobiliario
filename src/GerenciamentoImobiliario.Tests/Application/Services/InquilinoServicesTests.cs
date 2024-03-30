using System;
using System.Collections.Generic;
using System.Linq;
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
        [Fact]
        public async Task GivenAGuidShouldRemoveTheInquilinoWithThatIdFromTheList()
        {
            var list = new List<Inquilino>();
            var inquilinoAdded = _utils.CreateValidInquilino();
            list.Add(inquilinoAdded);
            _repository.Setup(x => x.Delete(It.IsAny<Guid>())).Callback<Guid>(x => list.RemoveAll(y => y.Id == x));
            var service = new InquilinoService(_repository.Object);
            await service.Delete(inquilinoAdded.Id);
            list.Count.Should().Be(0);
        }
        [Fact]
        public async Task ShouldReturnInquilinoWithTheSameIdAsSearched()
        {
            var list = new List<Inquilino>();
            var inquilinoAdded = _utils.CreateValidInquilino();
            list.Add(inquilinoAdded);
            _repository.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(list.First(x => x.Id == inquilinoAdded.Id));
            var service = new InquilinoService(_repository.Object);
            var result = await service.GetById(inquilinoAdded.Id);

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(inquilinoAdded);
        }
        [Fact]
        public async Task ShouldReturnAllInquilinosInTheList()
        {
            var list = new List<Inquilino>();
            var size = 100;
            for (int i = 0; i < size; i++)
            {
                list.Add(_utils.CreateValidInquilino());
            }

            _repository.Setup(x => x.GellAll()).ReturnsAsync(list);
            var service = new InquilinoService(_repository.Object);
            var result = await service.GellAll();

            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            result.Count().Should().Be(size);
        }

        [Fact]
        public async Task ShouldUpdateTheInquilinoWithTheCorrectInformationById()
        {
            var list = new List<Inquilino>();
            var inquilinoAdded = _utils.CreateValidInquilino();
            list.Add(inquilinoAdded);
            var inquilinoUpdated = _utils.CreateValidInquilino();
            _repository.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(list.First(x => x.Id == inquilinoAdded.Id));
            var service = new InquilinoService(_repository.Object);
            var inquilino = await service.GetById(inquilinoAdded.Id);
            var inputRequest = new InquilinoRequest(inquilinoUpdated.Nome, inquilinoUpdated.CPF);
            var result = await service.Update(inputRequest, inquilino.Id);

            result.Should().NotBeNull();
            result.CPF = inquilinoUpdated.CPF;
            result.Nome = inquilinoUpdated.Nome;
            result.AtualizadoEm.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(1));
            result.ImovelAlugado = inquilinoUpdated.ImovelAlugado;
        }


    }
}
