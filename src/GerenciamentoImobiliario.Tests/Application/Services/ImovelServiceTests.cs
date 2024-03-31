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
    public class ImovelServiceTests 
    {
        private readonly TestUtils _utils;
        private readonly Mock<IImovelRepository> _repository;
        public ImovelServiceTests()
        {
            _utils = new TestUtils();
            _repository = new Mock<IImovelRepository>();
        }
        [Fact]
        public async Task ShouldAdd1ToTheResultAfterInsertANewInquilinoAsync()
        {
            var list = new List<Imovel>();
            _repository.Setup(x => x.Create(It.IsAny<Imovel>())).Callback<Imovel>(x => list.Add(x));
            var service = new ImovelService(_repository.Object);
            var entity = _utils.CreateValidImovel();
            var input = new ImovelRequest();
            input.Nome = entity.Nome;
            input.ProprietarioId = _utils.CreateValidProprietario().Id;

            await service.Create(input);
            list.Count.Should().Be(1);
        }

       public async Task GivenAGuidShouldRemoveTheInquilinoWithThatIdFromTheList()
       {
           var list = new List<Imovel>();
           var imovelAdded = _utils.CreateValidImovel();
           list.Add(imovelAdded);
           _repository.Setup(x => x.Delete(It.IsAny<Guid>())).Callback<Guid>(x => list.RemoveAll(y => y.Id == x));
           var service = new ImovelService(_repository.Object);
           await service.Delete(imovelAdded.Id);
           list.Count.Should().Be(0);
       }
       [Fact]
       public async Task ShouldReturnInquilinoWithTheSameIdAsSearched()
       {
           var list = new List<Imovel>();
           var imovelAdded = _utils.CreateValidImovel();
           list.Add(imovelAdded);
           _repository.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(list.First(x => x.Id == imovelAdded.Id));
           var service = new ImovelService(_repository.Object);
           var result = await service.GetById(imovelAdded.Id);

           result.Should().NotBeNull();
           result.Proprietario.Should().Be(imovelAdded.Proprietario);
           result.Nome.Should().Be(imovelAdded.Nome);
       }
       [Fact]
       public async Task ShouldReturnAllInquilinosInTheList()
       {
           var list = new List<Imovel>();
           var size = 100;
           for (int i = 0; i < size; i++)
           {
               list.Add(_utils.CreateValidImovel());
           }

           _repository.Setup(x => x.GellAll()).ReturnsAsync(list);
           var service = new ImovelService(_repository.Object);
           var result = await service.GellAll();

           result.Should().NotBeNull();
           result.Should().NotBeEmpty();
           result.Count().Should().Be(size);
       }

       [Fact]
       public async Task ShouldUpdateTheInquilinoWithTheCorrectInformationById()
       {
           var list = new List<Imovel>();
           var imovelAdded = _utils.CreateValidImovel();
           list.Add(imovelAdded);
           var imovelUpdated = _utils.CreateValidImovel();
           _repository.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(list.First(x => x.Id == imovelAdded.Id));
           var service = new ImovelService(_repository.Object);
           var imovel = await service.GetById(imovelAdded.Id);
           var inputRequest = new ImovelRequest();
           inputRequest.Nome = imovelAdded.Nome;
           inputRequest.ProprietarioId = imovelAdded.ProprietarioId;
           var result = await service.Update(inputRequest, imovel.Id);

           result.Should().NotBeNull();
           result.Nome = imovelUpdated.Nome;
           result.Proprietario = imovelUpdated.Proprietario;
           result.AtualizadoEm.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(1));
           
       }


    }
}
