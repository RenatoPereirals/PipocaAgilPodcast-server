using System;
using System.ComponentModel.DataAnnotations;
using Xunit;
using PipocaAgilPodcast.Infrastructure.ValidationAttributes;

public class MinimumAgeAttributeTests
{
    [Fact]
    public void ValidDateOfBirthIsValid()
    {
        // Arrange
        var attribute = new MinimumAgeAttribute(18);
        var validDateOfBirth = DateTime.Today.AddYears(-19); // 19 anos de idade

        // Act
        var result = attribute.GetValidationResult(validDateOfBirth, new ValidationContext(validDateOfBirth));

        // Assert
        Assert.Null(result); // Deve ser válido
    }

    [Fact]
    public void YoungerDateOfBirthIsInvalid()
    {
        // Arrange
        var attribute = new MinimumAgeAttribute(18);
        var youngerDateOfBirth = DateTime.Today.AddYears(-17); // 17 anos de idade

        // Act
        var result = attribute.GetValidationResult(youngerDateOfBirth, new ValidationContext(youngerDateOfBirth));

        // Assert
        Assert.NotNull(result); // Deve ser inválido
        Assert.Equal("Você deve ter pelo menos 18 anos.", result.ErrorMessage);
    }

    [Fact]
    public void LeapYearDateOfBirthIsValid()
    {
        // Arrange
        var attribute = new MinimumAgeAttribute(18);
        var leapYearDateOfBirth = new DateTime(2000, 2, 29); // 22 anos de idade em 2022 (ano bissexto)

        // Act
        var result = attribute.GetValidationResult(leapYearDateOfBirth, new ValidationContext(leapYearDateOfBirth));

        // Assert
        Assert.Null(result); // Deve ser válido
    }
}
