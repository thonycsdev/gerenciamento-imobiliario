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
    public class ProprietarioServiceTests 
    {
        private readonly TestUtils _utils;
        private readonly Mock<IProprietarioRepository> _repository;
        public ProprietarioServiceTests()
        {
            _utils = new TestUtils();
            _repository = new Mock<IProprietarioRepository>();
        }
        [Fact]
        public async Task ShouldAdd1ToTheResultAfterInsertANewInquilinoAsync()
        {
            var list = new List<Proprietario>();
            _repository.Setup(x => x.Create(It.IsAny<Proprietario>())).Callback<Proprietario>(x => list.Add(x));
            var service = new ProprietarioService(_repository.Object);
            var entity = _utils.CreateValidProprietario();
            var input = new ProprietarioRequest();
            input.Nome = entity.Nome;
            input.CPF = entity.CPF;

            await service.Create(input);
            list.Count.Should().Be(1);
        }

       public async Task GivenAGuidShouldRemoveTheInquilinoWithThatIdFromTheList()
       {
           var list = new List<Proprietario>();
           var inquilinoAdded = _utils.CreateValidProprietario();
           list.Add(inquilinoAdded);
           _repository.Setup(x => x.Delete(It.IsAny<Guid>())).Callback<Guid>(x => list.RemoveAll(y => y.Id == x));
           var service = new ProprietarioService(_repository.Object);
           await service.Delete(inquilinoAdded.Id);
           list.Count.Should().Be(0);
       }
       [Fact]
       public async Task ShouldReturnInquilinoWithTheSameIdAsSearched()
       {
           var list = new List<Proprietario>();
           var inquilinoAdded = _utils.CreateValidProprietario();
           list.Add(inquilinoAdded);
           _repository.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(list.First(x => x.Id == inquilinoAdded.Id));
           var service = new ProprietarioService(_repository.Object);
           var result = await service.GetById(inquilinoAdded.Id);

           result.Should().NotBeNull();
           result.Should().BeEquivalentTo(inquilinoAdded);
       }
       [Fact]
       public async Task ShouldReturnAllInquilinosInTheList()
       {
           var list = new List<Proprietario>();
           var size = 100;
           for (int i = 0; i < size; i++)
           {
               list.Add(_utils.CreateValidProprietario());
           }

           _repository.Setup(x => x.GellAll()).ReturnsAsync(list);
           var service = new ProprietarioService(_repository.Object);
           var result = await service.GellAll();

           result.Should().NotBeNull();
           result.Should().NotBeEmpty();
           result.Count().Should().Be(size);
       }

       [Fact]
       public async Task ShouldUpdateTheInquilinoWithTheCorrectInformationById()
       {
           var list = new List<Proprietario>();
           var inquilinoAdded = _utils.CreateValidProprietario();
           list.Add(inquilinoAdded);
           var inquilinoUpdated = _utils.CreateValidProprietario();
           _repository.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(list.First(x => x.Id == inquilinoAdded.Id));
           var service = new ProprietarioService(_repository.Object);
           var inquilino = await service.GetById(inquilinoAdded.Id);
           var inputRequest = new ProprietarioRequest();
           inputRequest.Nome = inquilinoAdded.Nome;
           inputRequest.CPF = inquilinoAdded.CPF;
           var result = await service.Update(inputRequest, inquilino.Id);

           result.Should().NotBeNull();
           result.CPF = inquilinoUpdated.CPF;
           result.Nome = inquilinoUpdated.Nome;
           result.AtualizadoEm.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(1));
           
       }


    }
}
