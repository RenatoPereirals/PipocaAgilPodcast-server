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

        private void ConfigureRepositoryForMethod<T>(Action<Mock<IRepositoryPesistence>, T> configureMethod, T method)
        {
            configureMethod(mockUserRepository, method);
            mockUserRepository.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(true);
        }

        private void AddUser(Mock<IRepositoryPesistence> repo, User user)
        {
            repo.Setup(r => r.Add(user));
        }

        private void UpdateUser(Mock<IRepositoryPesistence> repo, User user)
        {
            repo.Setup(r => r.Update(user));
        }

        private void DeleteUser(Mock<IRepositoryPesistence> repo, User user)
        {
            repo.Setup(r => r.Delete(user));
        }

        private void DeleteRangeUser(Mock<IRepositoryPesistence> repo, User[] users)
        {
            repo.Setup(r => r.DeleteRange(users));
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
                ConfigureRepositoryForMethod(AddUser, user);
            }
            else
            {
            if (expectedExceptionType == typeof(UserAlreadyExistsException))
                {
                    mockUserRepository.Setup(repo => 
                    repo.Add(It.IsAny<User>())).Throws(
                        new UserAlreadyExistsException("Usuário já está cadastrado.", null, 409));
                }
                else if (expectedExceptionType == typeof(UserCreationException))
                {
                    mockUserRepository.Setup(repo => 
                    repo.Add(It.IsAny<User>())).Throws(
                        new UserCreationException("Erro ao criar o usuário.", null, 500));
                }
                else if (expectedExceptionType == typeof(UserValidationFailedException))
                {
                    mockUserRepository.Setup(repo => 
                    repo.Add(It.IsAny<User>())).Throws(new UserValidationFailedException(
                        "Erro ao validar o cadastro.", new ValidationException(), 400));
                }
                else
                {
                    mockUserRepository.Setup(repo => 
                    repo.Add(It.IsAny<User>())).Throws(new UserHandlingException(
                        "Erro inesperado ao criar o usuário.", new Exception()));
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
                ConfigureRepositoryForMethod(UpdateUser, user);
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

                    Assert.IsType(expectedExceptionType, exception);
                    Assert.Equal(expectedStatusCode, response.StatusCode);
                    Assert.Equal(expectedMessage, response.Message);
                }
            }
        }

        [Theory]
        [InlineData(true, 204, "Usuários deletados com sucesso.", null)]
        [InlineData(false, 500, "Erro ao deletar o usuário.", typeof(UserDeletedFailedException))]
        public async Task DeleteUser_VariousScenarios(bool isSuccess, int expectedStatusCode, string expectedMessage, Type expectedExceptionType)
        {
            // Arrange
            var user = new User();
            
            // Configurar o mock do UserRepository para simular sucesso ou falha
            if (isSuccess)
            {
                ConfigureRepositoryForMethod(DeleteUser, user);
            }
            else
            {
                if (expectedExceptionType == typeof(UserDeletedFailedException))
                {
                    mockUserRepository.Setup(repo => repo.Delete(It.IsAny<User>())).Throws(new UserDeletedFailedException("Erro ao deletar o usuário.", null, 500));
                }
                else
                {
                    mockUserRepository.Setup(repo => repo.Delete(It.IsAny<User>())).Throws(new UserHandlingException("Erro inesperado ao deletar o usuário.", new Exception()));
                }

            mockUserRepository.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(false);
            }

            // Act
            ServiceResponse response = null;
            Exception exception = null;
            try
            {
                response = await userRepository.DeleteUser(user);
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

                    Assert.IsType(expectedExceptionType, exception);
                    Assert.Equal(expectedStatusCode, response.StatusCode);
                    Assert.Equal(expectedMessage, response.Message);
                }
            }
        }
        
        [Theory]
        [InlineData(true, 204, "Usuários deletados com sucesso.", null)]
        [InlineData(false, 500, "Erro ao deletar o usuários.", typeof(UserDeletedFailedException))]
        public async Task DeleteRangeUser_VariousScenarios(bool isSuccess, int expectedStatusCode, string expectedMessage, Type expectedExceptionType)
        {
            // Arrange
            var user = new User[]
            {
                new User { Id = 1 },
                new User { Id = 2 },
                new User { Id = 3 }
            };
            
            // Configurar o mock do UserRepository para simular sucesso ou falha
            if (isSuccess)
            {
                ConfigureRepositoryForMethod(DeleteRangeUser, user);
            }
            else
            {
                if (expectedExceptionType == typeof(UserDeletedFailedException))
                {
                    mockUserRepository.Setup(repo => repo.DeleteRange(It.IsAny<User[]>())).Throws(new UserDeletedFailedException("Erro ao deletar o usuários.", null, 500));
                }
                else
                {
                    mockUserRepository.Setup(repo => repo.DeleteRange(It.IsAny<User[]>())).Throws(new UserHandlingException("Erro inesperado ao deletar o usuários.", new Exception()));
                }

            mockUserRepository.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(false);
            }

            // Act
            ServiceResponse response = null;
            Exception exception = null;
            try
            {
                response = await userRepository.DeleteRangeUser(user);
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

                    Assert.IsType(expectedExceptionType, exception);
                    Assert.Equal(expectedStatusCode, response.StatusCode);
                    Assert.Equal(expectedMessage, response.Message);
                }
            }
        }
    }

