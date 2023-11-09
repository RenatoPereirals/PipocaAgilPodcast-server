using PipocaAgilPodcast.Application.DTOs;
using System.ComponentModel.DataAnnotations;

namespace tests.UnitTests.Application.DTOs;

    public class UserDTOTests
    {
        [Fact]
        public void UserDTO_DefaultConstructor_SetsDefaultValues()
        {
            // Arrange & Act
            var userDto = new UserDTO();

            // Assert
            Assert.Equal(0, userDto.Id);
            Assert.Equal(string.Empty, userDto.FullName);
            Assert.Equal(string.Empty, userDto.UserName);
            Assert.Equal(string.Empty, userDto.ImageURL);
            Assert.Equal(default(DateTime), userDto.DateOfBirth);
            Assert.NotNull(userDto.Interests);
            Assert.NotNull(userDto.UsersActivitiesLogs);
        }

         [Fact]
        public void UserDTO_ParameterizedConstructor_SetsPropertyValues()
        {
            // Arrange
            int id = 1;
            string fullName = "John Doe";
            string userName = "johndoe";
            string imageURL = "profile.jpg";
            DateTime dateOfBirth = new DateTime(1990, 1, 1);

            // Act
            var userDto = new UserDTO(id, fullName, userName, imageURL, dateOfBirth);

            // Assert
            Assert.Equal(id, userDto.Id);
            Assert.Equal(fullName, userDto.FullName);
            Assert.Equal(userName, userDto.UserName);
            Assert.Equal(imageURL, userDto.ImageURL);
            Assert.Equal(dateOfBirth, userDto.DateOfBirth);
        }

        [Fact]
        public void UserDTO_DefaultConstructor_InitializesCollections()
        {
            // Arrange & Act
            var userDto = new UserDTO();

            // Assert
            Assert.NotNull(userDto.Interests);
            Assert.NotNull(userDto.UsersActivitiesLogs);
        }

        [Fact]
        public void UserDTO_ValidationAttributes()
        {
            // Arrange
            var userDto = new UserDTO
            {
                Id = 1,
                FullName = "John Doe",
                UserName = "johndoe",
                ImageURL = "profile.jpg",
                DateOfBirth = new DateTime(1990, 1, 1)
            };

            // Act
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(userDto);

            Validator.TryValidateObject(userDto, context, validationResults, validateAllProperties: true);

            // Assert
            Assert.Empty(validationResults);
        }

        [Fact]
        public void UserDTO_ValidationAttributes_InvalidDateOfBirth()
        {
            // Arrange
            var userDto = new UserDTO
            {
                Id = 1,
                FullName = "John Doe",
                UserName = "johndoe",
                ImageURL = "profile.jpg",
                DateOfBirth = DateTime.Now // data de nascimento inválda
            };

            // Act
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(userDto);

            Validator.TryValidateObject(userDto, context, validationResults, validateAllProperties: true);

            // Assert
            Assert.Single(validationResults); // deve ter um erro de validação
            Assert.Contains("Você deve ter pelo menos 18 anos.", validationResults[0].ErrorMessage);
        }
    }
    
