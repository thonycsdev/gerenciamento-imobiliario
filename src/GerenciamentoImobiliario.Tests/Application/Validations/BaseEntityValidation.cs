using System;
using FluentAssertions;
using GerenciamentoImobiliario.Application.DTOs.Request;
using GerenciamentoImobiliario.Exception;
using GerenciamentoImobiliario.Tests.Common;
using Xunit;

namespace GerenciamentoImobiliario.Tests.Application.Validations
{
    public class BaseEntityValidationTests
    {
            
        private readonly TestUtils _utils;
        public BaseEntityValidationTests()
        {
            _utils = new TestUtils();
        }
        [Fact]
        public void ShouldThrowAnErrorWhenTheNameInTheRequestIsNullOrEmpty()
        {
            var request = new InquilinoRequest();
            request.CPF = _utils._faker.Person.FullName;
            Action action = () => InquilinoRequest.ToDomainEntity(request);

            action.Should().Throw<EntityException>();

        }
    }
}
