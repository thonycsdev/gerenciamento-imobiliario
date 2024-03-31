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
    public class CorretorServiceTests
    {
        private readonly TestUtils _utils;
        private readonly Mock<ICorretorRepository> _repository;
        private readonly ICorretorService service;
        public CorretorServiceTests()
        {
            _utils = new TestUtils();
            _repository = new Mock<ICorretorRepository>();
            service = new CorretorService(_repository.Object, _utils.CreateMockMapper());
        }
        [Fact]
        public async Task ShouldAdd1ToTheResultAfterInsertANewCorretorAsync()
        {
            var list = new List<Corretor>();
            _repository.Setup(x => x.Create(It.IsAny<Corretor>())).Callback<Corretor>(x => list.Add(x));
            var input = new CorretorRequest(){
                Nome = "Anthony"
            };
            await service.Create(input);
            list.Count.Should().Be(1);
        }

        public async Task GivenAGuidShouldRemoveTheCorretorWithThatIdFromTheList()
        {
            var list = new List<Corretor>();
            var corretorAdded = _utils.CreateValidCorretor();
            list.Add(corretorAdded);
            _repository.Setup(x => x.Delete(It.IsAny<Guid>())).Callback<Guid>(x => list.RemoveAll(y => y.Id == x));
            await service.Delete(corretorAdded.Id);
            list.Count.Should().Be(0);
        }
        [Fact]
        public async Task ShouldReturnCorretorWithTheSameIdAsSearched()
        {
            var list = new List<Corretor>();
            var corretorAdded = _utils.CreateValidCorretor();
            list.Add(corretorAdded);
            _repository.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(list.First(x => x.Id == corretorAdded.Id));
            var result = await service.GetById(corretorAdded.Id);

            result.Should().NotBeNull();
            result.Nome.Should().Be(corretorAdded.Nome);
        }
        [Fact]
        public async Task ShouldReturnAllCorretorsInTheList()
        {
            var list = new List<Corretor>();
            var size = 100;
            for (int i = 0; i < size; i++)
            {
                list.Add(_utils.CreateValidCorretor());
            }

            _repository.Setup(x => x.GellAll()).ReturnsAsync(list);
            var result = await service.GellAll();

            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            result.Count().Should().Be(size);
        }

        [Fact]
        public async Task ShouldUpdateTheCorretorWithTheCorrectInformationById()
        {

        }


    }
}
