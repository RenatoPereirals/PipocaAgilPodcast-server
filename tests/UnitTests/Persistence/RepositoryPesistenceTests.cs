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
        mockDbContext.Setup(db => 
            db.SaveChangesAsync(default)).Returns(Task.FromResult(1));

        var repository = new RepositoryPesistence(mockDbContext.Object);

        var entity = new UserMock();

        // Act
        repository.Add(entity);
        repository.SaveChangesAsync().Wait();

        // Assert
        mockDbContext.Verify(db => db.Add(entity), Times.Once); // Chama o método Add
        mockDbContext.Verify(db => db.SaveChangesAsync(default), Times.Once); // Chama o método SaveChangesAsync
    }
    [Fact]
    public void Update_WithValidData_SavesToDatabase()
    {
        // Arrange
        var mockDbContext = new Mock<PipocaAgilPodcastDbContext>();
        mockDbContext.Setup(db => 
            db.SaveChangesAsync(default)).Returns(Task.FromResult(1));

        var repository = new RepositoryPesistence(mockDbContext.Object);

        var entity = new UserMock();

        // Act
        repository.Update(entity);
        repository.SaveChangesAsync().Wait();

        // Assert
        mockDbContext.Verify(db => db.Update(entity), Times.Once); // chama o método Update
        mockDbContext.Verify(db => db.SaveChangesAsync(default), Times.Once); // Chama o método SaveChangesAsync
    }
    [Fact]
    public void Delete_WithValidData_DeleteEntitiyToDatabase()
    {
        // Arrange
        var mockDbContext = new Mock<PipocaAgilPodcastDbContext>();
        mockDbContext.Setup(db => 
            db.SaveChangesAsync(default)).Returns(Task.FromResult(1));

        var repository = new RepositoryPesistence(mockDbContext.Object);

        var entity = new UserMock();

        // Act
        repository.Delete(entity);
        repository.SaveChangesAsync().Wait();

        // Assert
        mockDbContext.Verify(db => db.Remove(entity), Times.Once); // chama o método Remove
        mockDbContext.Verify(db => db.SaveChangesAsync(default), Times.Once); // Chama o método SaveChangesAsync
    }
    [Fact]
    public void DeleteRange_WithValidData_DeletesEntitiesFromDatabase()
    {
        // Arrange
        var mockDbContext = new Mock<PipocaAgilPodcastDbContext>();
        var repository = new RepositoryPesistence(mockDbContext.Object);

        var entitiesToDelete = new UserMock[]
        {
            new UserMock { Id = 1 },
            new UserMock { Id = 2 },
            new UserMock { Id = 3 }
        };

        // Act
        repository.DeleteRange(entitiesToDelete);
        repository.SaveChangesAsync().Wait();

        // Assert
        mockDbContext.Verify(db => db.RemoveRange(entitiesToDelete), Times.Once); // chama o método RomoveRange
        mockDbContext.Verify(db => db.SaveChangesAsync(default), Times.Once); // Chama o método SaveChangesAsync
    }
}

