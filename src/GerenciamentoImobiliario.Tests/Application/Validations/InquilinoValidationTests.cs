using System;
using FluentAssertions;
using GerenciamentoImobiliario.Application.DTOs.Request;
using GerenciamentoImobiliario.Exception;
using GerenciamentoImobiliario.Tests.Common;
using Xunit;

namespace GerenciamentoImobiliario.Tests.Application.Validations
{
    public class InquilinoValidationTests
    {
        private readonly TestUtils _utils;
        public InquilinoValidationTests()
        {
            _utils = new TestUtils();
        }
        [Fact]
        public void ShouldThrowAnErrorWhenCPFIsEmpty()
        {
            var request = new InquilinoRequest();
            request.Nome = _utils._faker.Person.FullName;
            Action action = () => InquilinoRequest.ToDomainEntity(request);

            action.Should().Throw<EntityException>();

        }
    }
}
