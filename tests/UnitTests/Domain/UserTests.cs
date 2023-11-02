using PipocaAgilPodcast.Domain;
using Xunit;

namespace tests.UnitTests.Domain;

    
    public class UserTests
    {
        [Fact]
        public void User_Constructor_InitializesCollections()
        {
            // Arrange
            User user = new User();

            // Assert
            Assert.NotNull (user.Interests);
            Assert.NotNull (user.UsersActivitiesLogs);
        }

        [Fact]
        public void User_DefaultValues_AreSet()
        {
            // Arrange
            User user = new User();

            // Assert
            Assert.Equal(string.Empty, user.FullName);
            Assert.Equal(string.Empty, user.UserName);
            Assert.Equal(string.Empty, user.ImageURL);
            Assert.Equal(DateTime.MinValue, user.DateOfBirth);
        }

        [Fact]
        public void User_Properties_CanBeSetAndGet()
        {
            // Arrange
            User user = new User();

            // Act
            user.FullName = "John Doe";
            user.UserName = "johndoe";
            user.ImageURL = "https://example.com/avatar.jpg";
            user.DateOfBirth = new DateTime(1990, 1, 1);

            // Assert
            Assert.Equal("John Doe", user.FullName);
            Assert.Equal("johndoe", user.UserName);
            Assert.Equal("https://example.com/avatar.jpg", user.ImageURL);
            Assert.Equal(new DateTime(1990, 1, 1), user.DateOfBirth);
        }
    }
    
