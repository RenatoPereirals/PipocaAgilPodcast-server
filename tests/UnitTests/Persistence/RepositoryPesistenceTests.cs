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
            mockDbContext.Setup(db => db.SaveChangesAsync(default)).Returns(Task.FromResult(1));
            repository = new RepositoryPesistence(mockDbContext.Object);
        }

        [Fact]
        public void  Create_WithValidData_SavesToDatabase()
        {
            // Arrange
            var entity = new UserMock();

            // Act
            repository.Add(entity);

            // Assert
            mockDbContext.Verify(db => db.Add(entity), Times.Once); // Verifique se Add foi chamado uma vez
        }

        [Fact]
        public void Update_WithValidData_SavesToDatabase()
        {
            // Arrange
            var entity = new UserMock();

            // Act
            repository.Update(entity);

            // Assert
            mockDbContext.Verify(db => db.Update(entity), Times.Once); // Verifique se Update foi chamado uma vez
        }

        [Fact]
        public void Delete_WithValidData_DeletesEntityFromDatabase()
        {
            // Arrange
            var entity = new UserMock();

            // Act
            repository.Delete(entity);

            // Assert
            mockDbContext.Verify(db => db.Remove(entity), Times.Once); // Verifique se Remove foi chamado uma vez
        }

        [Fact]
        public void DeleteRange_WithValidData_DeletesEntitiesFromDatabase()
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
            mockDbContext.Verify(db => db.RemoveRange(entitiesToDelete), Times.Once); // Verifique se RemoveRange foi chamado uma vez
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
            mockDbContext.Verify(db => db.SaveChangesAsync(default), Times.Once); // Verifique se SaveChangesAsync foi chamado uma vez
        }
    }

