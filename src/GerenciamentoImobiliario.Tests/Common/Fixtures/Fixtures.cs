using AutoFixture;
using Bogus;

namespace GerenciamentoImobiliario.Tests.Common.Fixtures
{
    public class FixturesDomain
    {

        private readonly Fixture _fixture;
        public readonly Faker _faker;

        public FixturesDomain()
        {
            _fixture =  new Fixture();
            _faker = new Faker("pt-br");
        }


    }
}
