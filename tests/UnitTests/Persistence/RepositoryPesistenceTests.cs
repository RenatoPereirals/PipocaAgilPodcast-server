using PipocaAgilPodcast.Persistence.Models;
using PipocaAgilPodcast.Persistence.Implementations;
using tests.FeatureTests;
using Moq;
using Xunit;

namespace PipocaAgilPodcast.Tests.Persistence;
    public class RepositoryPesistenceTests
    {
        private Mock<PipocaAgilPodcastDbContext> mockDbContext;
        private RepositoryPesistence repository;

        public RepositoryPesistenceTests()
        {
            // Configuração comum para todos os testes
            mockDbContext = new Mock<PipocaAgilPodcastDbContext>();
            repository = new RepositoryPesistence(mockDbContext.Object);
        }

        [Fact]
        public void  Create_WithValidData()
        {
            // Arrange
            var entity = new UserMock();

            // Act
            repository.Add(entity);

            // Assert
            mockDbContext.Verify(db => db.Add(entity), Times.Once); // Verifica se o método Add foi chamado uma vez
        }

        [Fact]
        public void Update_WithValidData()
        {
            // Arrange
            var entity = new UserMock();

            // Act
            repository.Update(entity);

            // Assert
            mockDbContext.Verify(db => db.Update(entity), Times.Once); // Verifica se o método Update foi chamado uma vez
        }

        [Fact]
        public void Delete_ValidData_DeleteEntityFromDatabase()
        {
            // Arrange
            var entity = new UserMock();

            // Act
            repository.Delete(entity);

            // Assert
            mockDbContext.Verify(db => db.Remove(entity), Times.Once); // Verifica se o método Remove foi chamado uma vez
        }

        [Fact]
        public void DeleteRange_ValidData_DeletesEntitiesFromDatabase()
        {
            // Arrange
            var entitiesToDelete = new UserMock[]
            {
                new UserMock { Id = 1 },
                new UserMock { Id = 2 },
                new UserMock { Id = 3 }
            };

            // Act
            repository.DeleteRange(entitiesToDelete);

            // Assert
            mockDbContext.Verify(db => db.RemoveRange(entitiesToDelete), Times.Once); // Verifica se o método RemoveRange foi chamado uma vez
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(0, false)]
        public async Task SaveChangesAsync_WhenChangesExist_ReturnsExpectedResult(int expectedResult, bool expectedValue)
        {
            // Arrange
            var mockDbContext = new Mock<PipocaAgilPodcastDbContext>();
            mockDbContext.Setup(db => db.SaveChangesAsync(default)).Returns(Task.FromResult(expectedResult));

            var repository = new RepositoryPesistence(mockDbContext.Object);

            // Act
            var result = await repository.SaveChangesAsync();

            // Assert
            Assert.Equal(expectedValue, result); // Verifica o resultado esperado (true, false)
            mockDbContext.Verify(db => db.SaveChangesAsync(default), Times.Once); // Verifica se o método SaveChangesAsync foi chamado uma vez
        }
    }

