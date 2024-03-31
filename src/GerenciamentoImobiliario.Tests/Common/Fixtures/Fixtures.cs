using System.Linq;
using AutoFixture;
using Bogus;

namespace GerenciamentoImobiliario.Tests.Common.Fixtures
{
    public class FixturesDomain
    {

        public readonly Fixture _fixture;
        public readonly Faker _faker;

        public FixturesDomain()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _faker = new Faker("pt_BR");
        }


    }
}
