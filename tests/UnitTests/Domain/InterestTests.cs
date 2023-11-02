using PipocaAgilPodcast.Domain;
using Xunit;

namespace tests.UnitTests.Domain;

    public class InterestTests
    {
        [Fact]
        public void Interest_Constructor_InitializesCollections()
        {
            // Arrange
            Interest interest = new Interest();

            // Assert
            Assert.NotNull(interest.Topic);
            Assert.NotNull(interest.User);
        }

        [Fact]
        public void Interest_DefaultValues_AreSet()
        {
            // Arrange
            Interest interest = new Interest();

            // Assert
            Assert.Equal(string.Empty, interest.Topic);
            Assert.Equal(DateTime.MinValue, interest.CreatedAt);
        }

        [Fact]
        public void Interest_Properties_CanBeSetAndGet()
        {
            // Arrange
            Interest interest = new Interest();

            // Act
            interest.Topic = "Exemplo";
            interest.CreatedAt = new DateTime(1990, 1, 1);

            // Assert
            Assert.Equal("Exemplo", interest.Topic);
            Assert.Equal(new DateTime(1990, 1, 1), interest.CreatedAt);
        }
    }

