using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livecode.Domain.DTO;
using Livecode.Domain.Interfaces;
using Livecode.Domain.Usecases;
using FluentAssertions;
using Moq;
using Livecode.Domain.Entities;
using Livecode.Tests.Fixtures;
using LanguageExt.Common;

namespace Livecode.Tests.Domain.Usecases;

public class CreateUserUsecaseTest
{
    [Theory]
    [AutoFixture()]
    public async Task CreateUserUsecaseTest_ShouldReturnUser(
        CreateUserDTO dto,
        Mock<IUserRepository> userRepository,
        User user
    )
    {
        userRepository
        .Setup(x => x.CreateUserAsync(dto))
        .ReturnsAsync(user);

        CreateUserUsecase createUserUsecase = new(userRepository.Object);
        var result = await createUserUsecase.CallAsync(dto);
        result.Should().NotBeNull();
        result.IsRight.Should().BeTrue();

        result.Match(
            Right: u => u.Should().Be(user),
            Left: _ => throw new Exception("Should not be left")
        );
    }
}