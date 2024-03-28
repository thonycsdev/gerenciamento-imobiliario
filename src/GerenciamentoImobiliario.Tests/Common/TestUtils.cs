using AutoFixture;
using Bogus;
using GerenciamentoImobiliario.Domain.Entities;
using Xunit;

namespace GerenciamentoImobiliario.Tests.Common
{
    public class TestUtils
    {
        private readonly Fixture _fixture;
        public readonly Faker _faker;
        public TestUtils()
        {
            _fixture = new Fixture();
            _faker = new Faker("pt_BR");
        }
        public Corretor CreateValidCorretor()
        {
            var corretor = new Corretor(_faker.Person.FullName);
            return corretor;
        }

        public Inquilino CreateValidInquilino()
        {
            var inquilino = new Inquilino(_faker.Person.FullName, _faker.Person.Random.String());
            return inquilino;
        }
        public Proprietario CreateValidProprietario()
        {
            var prop = new Proprietario(_faker.Person.FullName, _faker.Person.Random.String());
            return prop;
        }
        public Imovel CreateValidImovel()
        {
            var imo = new Imovel(_faker.Company.CompanyName(), CreateValidProprietario());
            return imo;
        }
        public void CreateValidLocation()
        {

        }
    }


    [CollectionDefinition(nameof(BaseFixtureCollection))]
    public class BaseFixtureCollection : ICollectionFixture<TestUtils> { }
}
