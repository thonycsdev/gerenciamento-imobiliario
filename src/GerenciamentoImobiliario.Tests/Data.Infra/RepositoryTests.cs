using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using GerenciamentoImobiliario.Data.Infra.DataContext;
using GerenciamentoImobiliario.Data.Infra.Repositories;
using GerenciamentoImobiliario.Domain.Entities;
using GerenciamentoImobiliario.Tests.Common;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace GerenciamentoImobiliario.Tests.Data.Infra
{
    public class RepositoryTests
    {
        private readonly TestUtils _utils;
        private readonly GerenciamentoImobiliarioDataContext _context;
        public RepositoryTests()
        {
            _utils = new TestUtils();
            _context = _utils.CreateEFCoreInMemoryContextDatabase();
        }
        [Fact]
        public async void GivenAEntityShouldAddOneToTheResultList()
        {
            var inquilino = _utils.CreateValidInquilino();
            var repository = new Repository<Inquilino>(_context);
            await repository.Create(inquilino);

            var result = await _context.Inquilinos.ToListAsync();
            result.Count.Should().Be(1);
        }
        [Fact]
        public async Task ShouldCreateDateTimeNowWhenCreatedAsync()
        {
            var inquilino = _utils.CreateValidInquilino();
            var repository = new Repository<Inquilino>(_context);
            await repository.Create(inquilino);

            var result = await _context.Inquilinos.FirstOrDefaultAsync(x => x.Id == inquilino.Id);
            result!.CriadoEm.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(1));
        }
        [Fact]
        public async void GivenAIdShouldRemoveTheEntityWithThatId()
        {

            var inquilinos = new List<Inquilino>();

            var inquilinoToRemove = _utils.CreateValidInquilino();

            inquilinos.Add(inquilinoToRemove);
            inquilinos.Add(_utils.CreateValidInquilino());
            await _context.AddRangeAsync(inquilinos);
            await _context.SaveChangesAsync();

            var repository = new Repository<Inquilino>(_context);
            await repository.Delete(inquilinoToRemove.Id);

            var resultList = await _context.Inquilinos.ToListAsync();

            resultList.Count.Should().Be(inquilinos.Count - 1);


        }
        [Fact]
        public async void ShouldReturnTheListWithTheCorrectCountOfEntities()
        {
            var inquilinos = new List<Inquilino>();
            for (int i = 0; i < 100; i++)
            {
                inquilinos.Add(_utils.CreateValidInquilino());
            }
            await _context.AddRangeAsync(inquilinos);
            await _context.SaveChangesAsync();

            var repository = new Repository<Inquilino>(_context);
            var resultList = await repository.GellAll();
            resultList.ToList().Count.Should().Be(inquilinos.Count);
        }
        [Fact]
        public async void GivenAnIdShouldRecoverTheEntityWithThatId()
        {

            var inquilinos = new List<Inquilino>();

            var inquilinoToFind = _utils.CreateValidInquilino();

            inquilinos.Add(inquilinoToFind);
            inquilinos.Add(_utils.CreateValidInquilino());
            await _context.AddRangeAsync(inquilinos);
            await _context.SaveChangesAsync();

            var repository = new Repository<Inquilino>(_context);

            var result = await repository.GetById(inquilinoToFind.Id);

            result.Id.Should().Be(inquilinoToFind.Id);
        }

        [Fact]
        public async void ShouldFindTheEntityByTheIdAndUpdateItsData()
        {


            var inquilinoToUpdate = _utils.CreateValidInquilino();
            var newInquilinoData = _utils.CreateValidInquilino();
            var repository = new Repository<Inquilino>(_context);
            await repository.Create(inquilinoToUpdate);
            var entity = await repository.GetById(inquilinoToUpdate.Id);

            entity.Nome = newInquilinoData.Nome;
            entity.CPF = newInquilinoData.CPF;
            entity.CriadoEm = newInquilinoData.CriadoEm;
            var result = await repository.Update(entity);

            result.AtualizadoEm.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(1));
            result.Nome.Should().Be(newInquilinoData.Nome);
            result.CPF.Should().Be(newInquilinoData.CPF);
        }
    }
}
