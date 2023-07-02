using EMS.Application.Common.Interfaces.Providers;
using EMS.Domain.Entities;
using EMS.Infrastructure.Authentication;

using FluentAssertions;

using Microsoft.Extensions.Options;

using Moq;

namespace EMS.Infrastructure.UnitTests.Authentication;

public class JwtTokenGeneratorTests
{
    private readonly JwtTokenGenerator _sut;

    private readonly Mock<IDateTimeProvider> _dateTimeProviderMock = new();

    private readonly Mock<IOptions<JwtSettings>> _jwtSettingsOptionsMock = new();

    public JwtTokenGeneratorTests()
    {
        TestSetup();

        _sut = new JwtTokenGenerator(_dateTimeProviderMock.Object, _jwtSettingsOptionsMock.Object);
    }

    [Theory]
    [MemberData(nameof(ValidUsers))]
    public void GenerateToken_WhenUserIsValid_ShouldReturnValidToken(User user)
    {
        // Act
        var token = _sut.GenerateToken(user);

        // Assert
        token.Should().NotBeNull();
        token.Should().NotBeEmpty();
        _dateTimeProviderMock.Verify(v => v.UtcNow, Times.Once);
    }

    public static IEnumerable<object[]> ValidUsers()
    {
        yield return new[]
        {
            new User { FirstName = "Chima", LastName = "Nwadike", EmailAddress = "chimanwadike94@gmail.com", PhoneNumber = "070332403034", Password = "1234567" },
        };
    }

    private void TestSetup()
    {
        _dateTimeProviderMock.Setup(d => d.UtcNow).Returns(DateTime.UtcNow);
        var jwtSettings = Options.Create(new JwtSettings() { ExpiryMinutes = 20, Secret = "ems-api-secret-key", Issuer = "EMS", Audience = "EMS" });
        _jwtSettingsOptionsMock.Setup(j => j.Value).Returns(jwtSettings.Value);
    }
}