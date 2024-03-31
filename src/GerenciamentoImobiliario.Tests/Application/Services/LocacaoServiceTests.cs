using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using GerenciamentoImobiliario.Application.DTOs.Request;
using GerenciamentoImobiliario.Application.Services;
using GerenciamentoImobiliario.Application.ServicesInterfaces;
using GerenciamentoImobiliario.Data.Infra.Interfaces;
using GerenciamentoImobiliario.Domain.Entities;
using GerenciamentoImobiliario.Tests.Common;
using Moq;
using Xunit;

namespace GerenciamentoImobiliario.Tests.Application.Services
{
    public class LocacaoServiceTests
    {
        private readonly TestUtils _utils;
        private readonly Mock<ILocacaoRepository> _repository;
        private readonly ILocacaoService service;
        public LocacaoServiceTests()
        {
            _utils = new TestUtils();
            _repository = new Mock<ILocacaoRepository>();
            service = new LocacaoService(_repository.Object, _utils.CreateMockMapper());
        }
        [Fact]
        public async Task ShouldAdd1ToTheResultAfterInsertANewLocacaoAsync()
        {
            var list = new List<Locacao>();
            _repository.Setup(x => x.Create(It.IsAny<Locacao>())).Callback<Locacao>(x => list.Add(x));
            var entity = _utils.CreateValidLocacao();
            var input = new LocacaoRequest();
            input.AlugadoAte = entity.AlugadoAte;
            input.ImovelId = entity.Imovel.Id;
            input.CorretorId = entity.Corretor.Id;
            input.InquilinoId = entity.Inquilino.Id;

            await service.Create(input);
            list.Count.Should().Be(1);
        }

        public async Task GivenAGuidShouldRemoveTheLocacaoWithThatIdFromTheList()
        {
            var list = new List<Locacao>();
            var locacaoAdded = _utils.CreateValidLocacao();
            list.Add(locacaoAdded);
            _repository.Setup(x => x.Delete(It.IsAny<Guid>())).Callback<Guid>(x => list.RemoveAll(y => y.Id == x));
            await service.Delete(locacaoAdded.Id);
            list.Count.Should().Be(0);
        }
        [Fact]
        public async Task ShouldReturnLocacaoWithTheSameIdAsSearched()
        {
            var list = new List<Locacao>();
            var locacaoAdded = _utils.CreateValidLocacao();
            list.Add(locacaoAdded);
            _repository.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(list.First(x => x.Id == locacaoAdded.Id));
            var result = await service.GetById(locacaoAdded.Id);

            result.Should().NotBeNull();
        }
        [Fact]
        public async Task ShouldReturnAllLocacaosInTheList()
        {
            var list = new List<Locacao>();
            var size = 100;
            for (int i = 0; i < size; i++)
            {
                list.Add(_utils.CreateValidLocacao());
            }

            _repository.Setup(x => x.GellAll()).ReturnsAsync(list);
            var result = await service.GellAll();

            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            result.Count().Should().Be(size);
        }

        [Fact]
        public async Task ShouldUpdateTheLocacaoWithTheCorrectInformationById()
        {
            var list = new List<Locacao>();
            var entity = _utils.CreateValidLocacao();
            list.Add(entity);

            _repository.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(list.First(x => x.Id == entity.Id));

            var entityUpdatedData = _utils.CreateValidLocacao();
            var input = new LocacaoRequest();
            input.AlugadoAte = entityUpdatedData.AlugadoAte;
            input.ImovelId = entityUpdatedData.Imovel.Id;
            input.CorretorId = entityUpdatedData.Corretor.Id;
            input.InquilinoId = entityUpdatedData.Inquilino.Id;
            var result = await service.Update(input, entity.Id);

        }


    }
}
