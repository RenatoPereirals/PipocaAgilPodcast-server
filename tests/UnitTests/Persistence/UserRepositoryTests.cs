using PipocaAgilPodcast.Persistence.Models;
using PipocaAgilPodcast.Persistence.Implementations;
using PipocaAgilPodcast.Persistence;
using tests.FeatureTests;
using Moq;
using Xunit;

namespace PipocaAgilPodcast.Tests.Persistence
{
    public class UserRepositoryTests
    {
        private Mock<PipocaAgilPodcastDbContext> mockDbContext;
        private UserRepository userRepository;

        public UserRepositoryTests()
        {
            // Configuração comum para todos os testes
            mockDbContext = new Mock<PipocaAgilPodcastDbContext>();
            userRepository = new UserRepository(mockDbContext.Object);
        }

        [Fact]
        public void UserRepository_Add_WithValidData()
        {
            // Arrange
            var user = new UserMock();

            // Act
            userRepository.Add(user);

            // Assert
            mockDbContext.Verify(db => db.Add(user), Times.Once);
        }

        [Fact]
        public void UserRepository_Update_ValidData()
        {
            // Arrange
            var user = new UserMock();

            // Act
            userRepository.Update(user);

            // Assert
            mockDbContext.Verify(db => db.Update(user), Times.Once);
        }

        [Fact]
        public void UserRepository_Delete_ValidData_DeletesEntityFromDatabase()
        {
            // Arrange
            var user = new UserMock();

            // Act
            userRepository.Delete(user);

            // Assert
            mockDbContext.Verify(db => db.Remove(user), Times.Once);
        }

        [Fact]
        public void UserRepository_DeleteRange_ValidData_DeletesEntitiesFromDatabase()
        {
            // Arrange
            var usersToDelete = new UserMock[]
            {
                new UserMock { Id = 1 },
                new UserMock { Id = 2 },
                new UserMock { Id = 3 }
            };

            // Act
            userRepository.DeleteRange(usersToDelete);

            // Assert
            mockDbContext.Verify(db => db.RemoveRange(usersToDelete), Times.Once);
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(0, false)]
        public async Task UserRepository_WhenChangesExist_ReturnsExpectedResult(int expectedResult, bool expectedValue)
        {
            // Arrange
            var mockDbContext = new Mock<PipocaAgilPodcastDbContext>();
            mockDbContext.Setup(db => db.SaveChangesAsync(default)).Returns(Task.FromResult(expectedResult));

            var userRepository = new RepositoryPesistence(mockDbContext.Object);

            // Act
            var result = await userRepository.SaveChangesAsync();

            // Assert
            Assert.Equal(expectedValue, result); // Verifica o resultado esperado (true, false)
            mockDbContext.Verify(db => db.SaveChangesAsync(default), Times.Once); // Verifica se o método SaveChangesAsync foi chamado uma vez
        }
    }
}
