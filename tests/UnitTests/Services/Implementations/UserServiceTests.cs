using Xunit;
using Moq;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

using PipocaAgilPodcast.Domain;
using PipocaAgilPodcast.Interfaces.ContractsPersistence;
using PipocaAgilPodcast.Services.Error;

namespace PipocaAgilPodcast.Services.Implementations.Tests;
    public class UserRepositoryTests
    {
        private Mock<IRepositoryPesistence> mockUserRepository;
        private UserRepository userRepository;

        public UserRepositoryTests()
        {
            mockUserRepository = new Mock<IRepositoryPesistence>();
            userRepository = new UserRepository(mockUserRepository.Object);
        }

        [Theory]
        [InlineData(true, 201, "Usuário criado com sucesso.", null)]
        [InlineData(false, 409, "Usuário já está cadastrado.", typeof(UserAlreadyExistsException))]
        [InlineData(false, 500, "Erro ao criar o usuário.", typeof(UserCreationException))]
        [InlineData(false, 400, "Erro ao validar o cadastro.", typeof(UserValidationFailedException))]
        public async Task CreateUser_VariousScenarios(bool isSuccess, int expectedStatusCode, string expectedMessage, Type expectedExceptionType)
        {
            // Arrange
            var user = new User();
            
            // Configurar o mock do UserRepository para simular sucesso ou falha
            if (isSuccess)
            {
                mockUserRepository.Setup(repo => repo.Add(It.IsAny<User>()));
                mockUserRepository.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(true);
            }
            else
            {
                if (expectedExceptionType == typeof(UserAlreadyExistsException))
                {
                    mockUserRepository.Setup(repo => repo.Add(It.IsAny<User>())).Throws(new UserAlreadyExistsException("Usuário já está cadastrado.", null, 409));
                }
                else if (expectedExceptionType == typeof(UserCreationException))
                {
                    mockUserRepository.Setup(repo => repo.Add(It.IsAny<User>())).Throws(new UserCreationException("Erro ao criar o usuário.", null, 500));
                }
                else if (expectedExceptionType == typeof(UserValidationFailedException))
                {
                    mockUserRepository.Setup(repo => repo.Add(It.IsAny<User>())).Throws(new UserValidationFailedException("Erro ao validar o cadastro.", new ValidationException(), 400));
                }
                else
                {
                    mockUserRepository.Setup(repo => repo.Add(It.IsAny<User>())).Throws(new UserHandlingException("Erro inesperado ao criar o usuário.", new Exception()));
                }

            mockUserRepository.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(false);
            }

            // Act
            ServiceResponse response = null;
            Exception exception = null;
            try
            {
                response = await userRepository.CreateUser(user);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            // Assert
            if (response != null)
            {
                if (isSuccess)
                {
                    Assert.True(response.IsSuccess);
                }
                else
                {
                    Assert.False(response.IsSuccess);
                    Assert.NotNull(exception);
                    Assert.IsType(expectedExceptionType, exception);
                    Assert.Equal(expectedStatusCode, response.StatusCode);
                    Assert.Equal(expectedMessage, response.Message);
                }
            }
        }

        [Theory]
        [InlineData(true, 200, "Usuário atualizado com sucesso.", null)]
        [InlineData(false, 500, "Erro ao atualizar o usuário.", typeof(UserCreationException))]
        [InlineData(false, 400, "Erro ao validar o cadastro.", typeof(UserValidationFailedException))]
        public async Task UpdateUser_VariousScenarios(bool isSuccess, int expectedStatusCode, string expectedMessage, Type expectedExceptionType)
        {
            // Arrange
            var user = new User();
            
            // Configurar o mock do UserRepository para simular sucesso ou falha
            if (isSuccess)
            {
                mockUserRepository.Setup(repo => repo.Update(It.IsAny<User>()));
                mockUserRepository.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(true);
            }
            else
            {
                if (expectedExceptionType == typeof(UserCreationException))
                {
                    mockUserRepository.Setup(repo => repo.Update(It.IsAny<User>())).Throws(new UserCreationException("Erro ao criar o usuário.", null, 500));
                }
                else if (expectedExceptionType == typeof(UserValidationFailedException))
                {
                    mockUserRepository.Setup(repo => repo.Update(It.IsAny<User>())).Throws(new UserValidationFailedException("Erro ao validar o cadastro.", new ValidationException(), 400));
                }
                else
                {
                    mockUserRepository.Setup(repo => repo.Update(It.IsAny<User>())).Throws(new UserHandlingException("Erro inesperado ao criar o usuário.", new Exception()));
                }

            mockUserRepository.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(false);
            }

            // Act
            ServiceResponse response = null;
            Exception exception = null;
            try
            {
                response = await userRepository.UpdateUser(user);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            // Assert
            if (response != null)
            {
                if (isSuccess)
                {
                    Assert.True(response.IsSuccess);
                }
                else
                {
                    Assert.False(response.IsSuccess);
                    Assert.NotNull(exception);
                    Assert.IsType(expectedExceptionType, exception);
                    Assert.Equal(expectedStatusCode, response.StatusCode);
                    Assert.Equal(expectedMessage, response.Message);
                }
            }
        }

    }

