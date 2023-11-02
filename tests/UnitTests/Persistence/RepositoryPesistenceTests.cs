using PipocaAgilPodcast.Persistence.Models;
using PipocaAgilPodcast.Persistence.Implementations;
using tests.FeatureTests;
using Moq;
using Xunit;

namespace PipocaAgilPodcast.Tests.Persistence;
    public class RepositoryPesistenceTests
{
    [Fact]
    public void  Create_WithValidData_SavesToDatabase()
    {
        // Arrange
        var mockDbContext = new Mock<PipocaAgilPodcastDbContext>();
        mockDbContext.Setup(db => db.SaveChangesAsync(default)).Returns(Task.FromResult(1));

        var repository = new RepositoryPesistence(mockDbContext.Object);

        var entity = new UserMock();

        // Act
        repository.Add(entity);
        repository.SaveChangesAsync().Wait();

        // Assert
        mockDbContext.Verify(db => db.SaveChangesAsync(default), Times.Once);
    }
}

